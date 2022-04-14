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
        public async Task<IActionResult> Post(IFormFile file) 
        {
            try
            { 
                if (file != null)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\UpLoad\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\UpLoad\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\UpLoad\\" + file.FileName))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();
                        return Ok(Result.Success("\\UpLoad\\" + file.FileName));
                    }
                }
                else
                {
                    return Ok(Result.Failure("File Null"));
                }
            }
            catch (Exception ex)
            {
                return Ok(Result.Failure(ex.ToString())); 
            }
        }
    }
}
