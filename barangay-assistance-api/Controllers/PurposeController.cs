using barangay_assistance_api.Helpers.Response;
using Base.Entities.Models;
using Base.Services.Helpers.Utility;
using Base.Services.Implementation.Complaints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace barangay_assistance_api.Controllers
{
    [Route("api/purpose")]
    [ApiController]
    [Authorize]
    public class PurposeController : ControllerBase
    {
        private readonly IPurposes _purpose;

        private readonly Logger _logger = new();

        public PurposeController(IPurposes purpose)
        {
            _purpose = purpose;
        }

        [HttpGet("complaints/get")]
        public IActionResult Complaints()
        {
            try
            {
                var complaints = _purpose.GetComplaints();
                return Ok(new ApiOkResponse(complaints));
            }
            catch (Exception x)
            {
                _logger.LogException(x, $"Get Complaints | :");
                return NotFound(new ApiResponse(500, x.Message));
            }
        }

        [HttpGet("assistance/get")]
        public IActionResult Assistances()
        {
            try
            {
                var asistance = _purpose.GetAssistance();
                return Ok(new ApiOkResponse(asistance));
            }
            catch (Exception x)
            {
                _logger.LogException(x, $"Get Assistances | :");
                return NotFound(new ApiResponse(500, x.Message));
            }
        }

        [HttpGet("status/get")]
        public IActionResult PurposeStatus()
        {
            try
            {
                var status = _purpose.GetAllPurposeStatus();
                return Ok(new ApiOkResponse(status));
            }
            catch (Exception x)
            {
                _logger.LogException(x, $"Get PurposeStatus | :");
                return NotFound(new ApiResponse(500, x.Message));
            }
        }

        [HttpPost("add")]
        [AllowAnonymous]
        public async Task<IActionResult> Add([FromBody] ComplaintsModel purposeObject)
        {
            int userId = 0;

            try
            {
                // get specific header
                Request.Headers.TryGetValue("id", out var id);

                // checking if user or admin (user == 0, admin > 0)
                if (id.Count > 0)
                {
                    userId = Convert.ToInt32(id.First());
                }

                await _purpose.Add(purposeObject, userId);

                return Ok(new ApiOkResponse());
            }
            catch (Exception x)
            {
                _logger.LogException(x, $"Add Purpose | purposeObject: {purposeObject} | userId: {userId}");
                return NotFound(new ApiResponse(500, x.Message));
            }
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] UpdatePurposeDTO purposeObject)
        {
            int userId = 0;

            try
            {
                // get specific header
                Request.Headers.TryGetValue("id", out var id);

                if (id.Count > 0)
                {
                    userId = Convert.ToInt32(id.First());
                    _purpose.Update(purposeObject, userId);

                    return Ok(new ApiOkResponse());
                }

                return NotFound(new ApiResponse(401));

            }
            catch (Exception x)
            {
                _logger.LogException(x, $"Update Purpose | purposeObject: {purposeObject} | userId: {userId}");
                return NotFound(new ApiResponse(500, x.Message));
            }
        }

        [HttpGet("delete/{purposeId}")]
        public IActionResult Delete(int purposeId)
        {
            int userId = 0;

            try
            {
                // get specific header
                Request.Headers.TryGetValue("id", out var id);

                if (id.Count > 0)
                {
                    userId = Convert.ToInt32(id.First());
                    _purpose.Delete(purposeId, userId);

                    return Ok(new ApiOkResponse());
                }

                return NotFound(new ApiResponse(401));

            }
            catch (Exception x)
            {
                _logger.LogException(x, $"Delete Purpose | purposeId: {purposeId} | userId: {userId}");
                return NotFound(new ApiResponse(500, x.Message));
            }
        }
    }
}
