using barangay_assistance_api.Helpers.Response;
using Base.Services.Helpers.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace barangay_assistance_api.Controllers
{
    [Route("api/upload")]
    [ApiController]
    [DisableRequestSizeLimit]
    public class UploadController : ControllerBase
    {
        private readonly Logger _logger;

        [HttpPost("")]
        public async Task<IActionResult> Upload(string type = "")
        {
            try
            {
                var file = Request.Form.Files[0];
                var path = await UploadFile.Photo(file, type);

                return Ok(path);
            }
            catch (Exception x)
            {
                _logger.LogException(x, $"Upload Image | type: {type}");
                return NotFound(new ApiResponse(500, x.Message));
            }
        }
    }
}
