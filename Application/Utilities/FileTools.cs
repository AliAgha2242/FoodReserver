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
        public long MaxFileSizeInByte { get; set; }
        public string[] FileValidExtension { get; set; } = {".jpg",".png",".mp4"};

        public async Task<(string ,string)> SaveFileAsync(IFormFile file, string folderName) //Folder Name Is Category Of Food
        {
            string folderAddress = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","Files",folderName);
            if(!Directory.Exists(folderAddress))
                Directory.CreateDirectory(folderAddress);

            string fileName = string.Concat(folderName,DateTime.Now.Ticks.ToString(),Path.GetExtension(file.FileName));


            string fileAddress = Path.Combine(folderAddress,fileName);
            using Stream stream = new FileStream(fileAddress, FileMode.Create,FileAccess.Write);
            {
                await file.CopyToAsync(stream);
            };
            return (string.Concat(@"/",Path.Combine(folderName,fileName)),fileName);
        }
        public bool CheckSize(IFormFile file)
        {
             return file.Length <= MaxFileSizeInByte ;
        }
        public bool CheckExtension(IFormFile file)
        {
            return FileValidExtension.Contains(Path.GetExtension(file.FileName).ToLower());
        }
        public bool IsNotNull(IFormFile file)
            { return file != null; }


    }
}
