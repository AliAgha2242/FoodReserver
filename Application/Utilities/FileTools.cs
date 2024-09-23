using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Permissions;

namespace Application.Utilities
{
    public class FileTools
    {
        public long MaxFileSizeInByte { get; set; } = 1024 * 1024 * 1024;
        public string[] FileValidExtension { get; set; } = { ".jpg", ".png", ".mp4" };
        public EncriptTools EncriptTools { get; }

        public FileTools(EncriptTools encriptTools)
        {
            EncriptTools = encriptTools;
        }

        public async Task<(string, string)> SaveFileAsync(IFormFile file, string folderName) //Folder Name Is Category Of Food
        {
            string folderAddress = Path.Combine(Directory.GetCurrentDirectory(), "Files", folderName);
            if (!Directory.Exists(folderAddress))
                Directory.CreateDirectory(folderAddress);

            string fileName = string.Concat(folderName, DateTime.Now.Ticks.ToString(), Path.GetExtension(file.FileName));
            string fileAddress = Path.Combine(folderAddress, fileName);


            var fileArray = EncriptTools.EncriptFile(file);

            using (var writer = new BinaryWriter(File.OpenWrite(fileAddress)))
            {
                writer.Write(fileArray);
            };

            string Address = string.Concat("/Files/", folderName, "/", fileName);
            return (Address, fileName);
        }



        public bool CheckSize(IFormFile file)
        {
            return file.Length <= MaxFileSizeInByte * 10;
        }
        public bool CheckExtension(IFormFile file)
        {
            return FileValidExtension.Contains(Path.GetExtension(file.FileName).ToLower());
        }
        public bool IsNotNull(IFormFile file)
        { return file != null; }
        public double GetFileSize(IFormFile file) { return file.Length; }

        public void RemoveFile(string address)
        {
            address = string.Concat(".", address);
            if (!File.Exists(address))
                return;
            File.Delete(address);
        }
        
    }
}
