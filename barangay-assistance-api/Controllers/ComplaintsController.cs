using Base.Core.Helpers;
using Base.Entities.Models;
using Base.Services.Implementation.Complaints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace barangay_assistance_api.Controllers
{
    [Route("api/complaints")]
    [ApiController]
    [Authorize]
    public class ComplaintsController : ControllerBase
    {
        private readonly IComplaints _complaints;

        public ComplaintsController(IComplaints complaints)
        {
            _complaints = complaints;
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            try
            {
                var complaints = _complaints.GetComplaints();
                return Ok(new ApiOkResponse(complaints));
            }
            catch (Exception x)
            {
                return NotFound(new ApiResponse(500, x.Message));
            }
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] ComplaintsModel compObject)
        {
            try
            {
                // get specific header
                Request.Headers.TryGetValue("id", out var id);
                var userId = Convert.ToInt32(id.First());

                // validate job name
                var valid = _complaints.ValidateComplaints(compObject.Complainant);

                if (valid)
                {
                    _complaints.Add(compObject, userId);
                    return Ok();
                }

                return BadRequest("Complaints already exist!");

            }
            catch (Exception x)
            {
                return NotFound(new ApiResponse(500, x.Message));
            }
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] ComplaintsModel jobObject)
        {
            try
            {
                // get specific header
                Request.Headers.TryGetValue("id", out var id);
                var userId = Convert.ToInt32(id.First());

                // validate job name
                var valid = _complaints.ValidateComplaints(jobObject.Complainant, jobObject.Id);

                if (valid)
                {
                    _complaints.Update(jobObject, userId);
                    return Ok();
                }

                return BadRequest("Job already exist!");

            }
            catch (Exception x)
            {
                return NotFound(new ApiResponse(500, x.Message));
            }
        }

        [HttpGet("delete/{complaintId}")]
        public IActionResult Delete(int jobId)
        {
            try
            {
                // get specific header
                Request.Headers.TryGetValue("id", out var id);
                var userId = Convert.ToInt32(id.First());

                _complaints.Delete(jobId, userId);
                return Ok();

            }
            catch (Exception x)
            {
                return NotFound(new ApiResponse(500, x.Message));
            }
        }
    }
}
