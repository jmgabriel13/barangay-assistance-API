﻿using barangay_assistance_api.Helpers.Utility;
using Base.Core.Helpers;
using Base.Entities.Models;
using Base.Services.Implementation.Complaints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;

namespace barangay_assistance_api.Controllers
{
    [Route("api/purpose")]
    [ApiController]
    public class PurposeController : ControllerBase
    {
        private readonly IComplaints _purpose;

        public PurposeController(IComplaints purpose)
        {
            _purpose = purpose;
        }

        [HttpGet("complaints/get")]
        [Authorize]
        public IActionResult Complaints()
        {
            try
            {
                var complaints = _purpose.GetComplaints();
                return Ok(new ApiOkResponse(complaints));
            }
            catch (Exception x)
            {
                return NotFound(new ApiResponse(500, x.Message));
            }
        }

        [HttpGet("assistance/get")]
        [Authorize]
        public IActionResult Assistances()
        {
            try
            {
                var asistance = _purpose.GetAssistance();
                return Ok(new ApiOkResponse(asistance));
            }
            catch (Exception x)
            {
                return NotFound(new ApiResponse(500, x.Message));
            }
        }

        [HttpGet("status/get")]
        [Authorize]
        public IActionResult PurposeStatus()
        {
            try
            {
                var status = _purpose.GetAllPurposeStatus();
                return Ok(new ApiOkResponse(status));
            }
            catch (Exception x)
            {
                return NotFound(new ApiResponse(500, x.Message));
            }
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] ComplaintsModel purposeObject)
        {
            try
            {
                // get specific header
                Request.Headers.TryGetValue("id", out var id);
                var userId = 0;

                if (id.Count > 0)
                {
                    userId = Convert.ToInt32(id.First());
                    _purpose.Add(purposeObject, userId);

                    return Ok(new ApiOkResponse());
                }

                purposeObject.Status = (int)EPurposeStatus.PENDING;
                _purpose.Add(purposeObject, userId);

                return Ok(new ApiOkResponse());
            }
            catch (Exception x)
            {
                return NotFound(new ApiResponse(500, x.Message));
            }
        }

        [HttpPut("update")]
        [Authorize]
        public IActionResult Update([FromBody] UpdatePurposeDTO purposeObject)
        {
            try
            {
                // get specific header
                Request.Headers.TryGetValue("id", out var id);

                if (id.Count > 0)
                {
                    var userId = Convert.ToInt32(id.First());
                    _purpose.Update(purposeObject, userId);

                    return Ok(new ApiOkResponse());
                }

                return NotFound(new ApiResponse(401));

            }
            catch (Exception x)
            {
                return NotFound(new ApiResponse(500, x.Message));
            }
        }

        [HttpGet("delete/{complaintId}")]
        [Authorize]
        public IActionResult Delete(int purposeId)
        {
            try
            {
                // get specific header
                Request.Headers.TryGetValue("id", out var id);

                if (id.Count > 0)
                {
                    var userId = Convert.ToInt32(id.First());
                    _purpose.Delete(purposeId, userId);

                    return Ok(new ApiOkResponse());
                }

                return NotFound(new ApiResponse(401));

            }
            catch (Exception x)
            {
                return NotFound(new ApiResponse(500, x.Message));
            }
        }
    }
}