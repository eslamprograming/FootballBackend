using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Football.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpPost]
        [Route("UploadFile")]
        public IActionResult UploadFile(IFormFile file)
        {
           var result= BLL.Helper.UploadFile.Save(file);
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeleteFile")]
        public IActionResult DeleteFile(string file)
        {
            var result = BLL.Helper.UploadFile.DeleteFileByLink(file);
            return Ok(result);
        }
    }
}
