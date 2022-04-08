using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebApiGP.Models;
using System.Threading.Tasks;

namespace WebApiGP.Controllers  
{
    [Route("api/[controller]")]
    public class UpLoadImageController : Controller
    {
        public static IWebHostEnvironment _environment;

        public UpLoadImageController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public class FileUploadApi
        {
            public IFormFile files { get; set; }
        }
        [HttpPost]
        public async Task<string> Post(FileUploadApi objFile)
        {
            try
            { 
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\UpLoad\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\UpLoad\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\UpLoad\\" + objFile.files.FileName))
                    {
                        objFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return "\\UpLoad\\" + objFile.files.FileName;
                    }
                }
                else
                {
                    return "fail";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
