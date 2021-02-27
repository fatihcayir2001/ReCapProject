using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadsController : ControllerBase
    {
        public static IWebHostEnvironment _wepHostEnvironment;
        public ImageUploadsController(IWebHostEnvironment wepHostEnvironment)
        {
            _wepHostEnvironment = wepHostEnvironment;
        }

        public string fileName = Guid.NewGuid().ToString();

        [HttpPost("add")]
        public string Post([FromForm]ImageUpload objectImage)
        {
            try
            {
                if (objectImage.files.Length >0)
                {
                    string path = _wepHostEnvironment.WebRootPath + "\\uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + fileName))
                    {
                        objectImage.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return "Uploaded";
                    }
                }
                else
                {
                    return "Not Uplaoded.";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
