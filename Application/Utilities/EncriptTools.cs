using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Application.Utilities
{
    public class EncriptTools
    {
        public IConfiguration Configuration { get; }

        public EncriptTools(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //private readonly EncriptionConfig configs;

        //public EncryptionUtility(IOptions<EncriptionConfig> options)
        //{
        //    this.configs = options.Value;
        //}
        public string GetSHA256(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = BitConverter.ToString(bytes).Replace("-", "").ToLower();
                return hash;
            }
        }

        public string GetNewSalt()
        {
            return Guid.NewGuid().ToString();
        }

        //    public string GetNewRefreshToken()
        //    {
        //        return Guid.NewGuid().ToString();
        //    }

        //    public string GetNewToken(Guid userId)
        //    {
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var key = Encoding.UTF8.GetBytes(configs.TokenKey);

        //        var tokenDescriptor = new SecurityTokenDescriptor
        //        {
        //            Subject = new ClaimsIdentity(new Claim[]
        //            {
        //                    new Claim("userId", userId.ToString()),
        //            }),

        //            Expires = DateTime.UtcNow.AddMinutes(configs.TokenTimeout),
        //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //        };

        //        var token = tokenHandler.CreateToken(tokenDescriptor);
        //        return tokenHandler.WriteToken(token);
        //    }
        //}
        public byte[] EncriptFile(IFormFile file)
        {
            byte[] fileContent = ConvertToByteArray(file);
            byte[] key = System.Text.Encoding.UTF8.GetBytes(Configuration.GetSection("EncriptConfiguration")["key"]);

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 }
                , 3, HashAlgorithmName.SHA256);

                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(fileContent, 0, fileContent.Length);
                        cryptoStream.FlushFinalBlock();
                        return memoryStream.ToArray() ;
                    }
                } 
            }
        }
        public byte[] DecryptFile(byte[] fileContent)
        {
            byte[] key = System.Text.Encoding.UTF8.GetBytes(Configuration.GetSection("EncriptConfiguration").Key);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 }
                , 3, HashAlgorithmName.SHA256);

                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);


                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(fileContent, 0, fileContent.Length);
                        cryptoStream.FlushFinalBlock();
                        return memoryStream.ToArray();
                    }
                }
            }
        }
        public byte[] DecryptFile(string address)
        {


            byte[] fileContent = File.ReadAllBytes("."+address) ;

            byte[] key = System.Text.Encoding.UTF8.GetBytes(Configuration.GetSection("EncriptConfiguration")["key"]);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 }
                , 3, HashAlgorithmName.SHA256);

                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);


                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(fileContent, 0, fileContent.Length);
                        cryptoStream.FlushFinalBlock();
                        return memoryStream.ToArray();
                    }
                }
            }
        }

        public byte[] ConvertToByteArray(IFormFile file)
        {
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                return stream.ToArray();
            }
        }
        public async Task<byte[]> ConvertToByteArray(string path)
        {
            return await File.ReadAllBytesAsync(path);
        }


    }
}
