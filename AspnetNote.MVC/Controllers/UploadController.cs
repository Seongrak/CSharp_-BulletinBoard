using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetNote.MVC.Controllers
{
    public class UploadController : Controller
    {
        private readonly IHostingEnvironment _environment; // to use "wwwroot"

        public UploadController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost, Route("api/upload")] //Defualt : www.abc.com/Upload/ImageUpload -> www.abc/api/upload
        public IActionResult ImageUpload(IFormFile file)
        {
            // When image or file is uploaded
            // 1. Path ; where to store
            // 2. File Name ; DateTime or GUID
            // 3. Extension ; jpg,png,... txt

            // Path
            var path = Path.Combine(_environment.WebRootPath,@"images\upload");
            // Name, Extension
            // var fileName = file.FileName; // original name of uploaded file
            var fileFullName = file.FileName.Split('.');
            var fileName = $"{Guid.NewGuid()}.{fileFullName[1]}";
            using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return Ok(new { file = "/images/upload/" + fileName, success = true });


        }
    }
}
