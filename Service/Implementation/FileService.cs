using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment= webHostEnvironment;
        }
        public async Task<string> UploadImage(string Loacation, IFormFile file)
        {
            var path = _webHostEnvironment.WebRootPath + "/" + Loacation + "/";
            var extension =Path.GetExtension(file.FileName);
            var filename = Guid.NewGuid().ToString().Replace("-",string.Empty)+extension;
            if(file.Length>0)
            {
                if(!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (FileStream fileStream =File.Create(path+filename))
                {
                    await file.CopyToAsync(fileStream);
                    await fileStream.FlushAsync();
                    return $"/{Loacation}/{filename}";
                }
            }
            else
            {
                return "NoImage";
            }

        }
    }
}
