﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities
{
    public class EncriptTools
    {
        //private readonly EncriptionConfig configs;

        //public EncryptionUtility(IOptions<EncriptionConfig> options)
        //{
        //    this.configs = options.Value;
        //}
        public string GetSHA256(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
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
    }
}
