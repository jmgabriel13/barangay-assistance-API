using barangay_assistance_api.Helpers.Utility;
using Base.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace barangay_assistance_api.Controllers
{
    [Route("api/upload")]
    [ApiController]
    [DisableRequestSizeLimit]
    public class UploadController : Controller
    {
        [HttpPost("")]
        public IActionResult Upload(string type = "")
        {
            try
            {
                var file = Request.Form.Files[0];
                var path = UploadFile.Photo(file, type);

                return Ok(path);
            }
            catch (Exception x)
            {
                return NotFound(new ApiResponse(500, x.Message));
            }
        }
    }
}
