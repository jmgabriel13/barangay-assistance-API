using barangay_assistance_api.Helpers.Utility;
using Base.Core.Helpers;
using Base.Entities.Models;
using Base.Services.Implementation.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace barangay_assistance_api.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IAccount _user;
        public UserController(IAccount user)
        {
            _user = user;
        }

        [HttpGet("get")]
        [Authorize]
        public IActionResult GetAllUsers()
        {
            try
            {
                var accounts = _user.GetAllAccounts();
                return Ok(new ApiOkResponse(accounts));
            }
            catch (Exception x)
            {
                return NotFound(new ApiResponse(500, x.Message));
            }
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] UserModel userObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiBadRequestResponse(ModelState));
            }

            try
            {
                // get specific header
                Request.Headers.TryGetValue("id", out var id);
                var userId = Convert.ToInt32(id.First());

                // validate
                if (_user.ValidateUsername(userObject.Username))
                    return BadRequest("Username already taken.");

                if (_user.ValidateEmail(userObject.Email))
                    return BadRequest("Email already taken.");

                //  encrypt password
                userObject.Password = Crypto.Encrypt(userObject.Password);

                _user.Add(userObject, 1);
                return Ok();
            }
            catch (Exception x)
            {
                return NotFound(new ApiResponse(500, x.Message));
            }
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] UserModel userObject)
        {
            try
            {
                // get specific header
                Request.Headers.TryGetValue("id", out var id);
                var userId = Convert.ToInt32(id.First());

                // validate
                if (_user.ValidateUsername(userObject.Username))
                    return BadRequest("Username already taken.");

                if (_user.ValidateEmail(userObject.Email))
                    return BadRequest("Email already taken.");

                _user.Update(userObject, userId);
                return Ok();
            }
            catch (Exception x)
            {
                return NotFound(new ApiResponse(500, x.Message));
            }
        }

        [HttpGet("delete/{userId}")]
        public IActionResult Delete(int userId)
        {
            try
            {
                // get specific header
                Request.Headers.TryGetValue("id", out var id);
                var userLoginId = Convert.ToInt32(id.First());

                _user.Delete(userId, userLoginId);
                return Ok();

            }
            catch (Exception x)
            {
                return NotFound(new ApiResponse(500, x.Message));
            }
        }
    }
}
