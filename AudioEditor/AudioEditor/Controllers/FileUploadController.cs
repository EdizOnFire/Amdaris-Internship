using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AudioEditor.Controllers
{
    [Route("audio-editor")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        public IWebHostEnvironment _hostingEnvironment;
        public FileUploadController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFileCollection files)
        {
            if (files.Count > 0)
            {
                foreach (var file in files)
                {
                    FileInfo fi = new(file.FileName);
                    var path = Path.Combine("", _hostingEnvironment.ContentRootPath + "/Files/" + fi);
                    using var stream = new FileStream(path, FileMode.Create);
                    {
                        file.CopyTo(stream);
                    }

                }

                return Ok("File/s uploaded.");
            }
            else
            {
                return BadRequest("Select file/s.");
            }
        }
    }
}
