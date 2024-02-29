using barangay_assistance_api.Helpers.Response;
using Base.Entities.Models;
using Base.Services.Helpers.Utility;
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

        private readonly Logger _logger = new();

        public UserController(IAccount user)
        {
            _user = user;
        }

        [HttpGet("get")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var accounts = _user.GetAllAccounts();
                return Ok(new ApiOkResponse(accounts));
            }
            catch (Exception x)
            {
                _logger.LogException(x, $"GetAllUsers | :");
                return NotFound(new ApiResponse(500, x.Message));
            }
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] UserModel userObject)
        {
            int userId = 0;

            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiBadRequestResponse(ModelState));
            }

            try
            {
                // get specific header
                Request.Headers.TryGetValue("id", out var id);
                userId = Convert.ToInt32(id.First());

                // validate
                if (_user.ValidateUsername(userObject.Username))
                    return BadRequest("Username already taken.");

                if (_user.ValidateEmail(userObject.Email))
                    return BadRequest("Email already taken.");

                _user.Add(userObject, userId);

                return Ok(new ApiOkResponse());
            }
            catch (Exception x)
            {
                _logger.LogException(x, $"Add User | userObject: {userObject.Serialize()} | userId: {userId}");
                return NotFound(new ApiResponse(500, x.Message));
            }
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] UserModel userObject)
        {
            int userId = 0;

            try
            {
                // get specific header
                Request.Headers.TryGetValue("id", out var id);
                userId = Convert.ToInt32(id.First());

                // validate
                if (_user.ValidateUsername(userObject.Username))
                    return BadRequest("Username already taken.");

                if (_user.ValidateEmail(userObject.Email))
                    return BadRequest("Email already taken.");

                _user.Update(userObject, userId);

                return Ok(new ApiOkResponse());
            }
            catch (Exception x)
            {
                _logger.LogException(x, $"Update User | userObject: {userObject.Serialize()} | userId: {userId}");
                return NotFound(new ApiResponse(500, x.Message));
            }
        }

        [HttpGet("delete/{userId}")]
        public IActionResult Delete(int userId)
        {
            int userLoginId = 0;

            try
            {
                // get specific header
                Request.Headers.TryGetValue("id", out var id);
                userLoginId = Convert.ToInt32(id.First());

                _user.Delete(userId, userLoginId);

                return Ok(new ApiOkResponse());
            }
            catch (Exception x)
            {
                _logger.LogException(x, $"Delete User | userId: {userId} | userLoginId: {userLoginId}");
                return NotFound(new ApiResponse(500, x.Message));
            }
        }

        [HttpGet("roles/get")]
        public IActionResult GetAllRoles()
        {
            try
            {
                var roles = _user.GetAllRoles();
                return Ok(new ApiOkResponse(roles));
            }
            catch (Exception x)
            {
                _logger.LogException(x, $"GetAllRoles | :");
                return NotFound(new ApiResponse(500, x.Message));
            }
        }

        [HttpGet("gender/get")]
        public IActionResult GetAllGenders()
        {
            try
            {
                var genders = _user.GetAllGender();
                return Ok(new ApiOkResponse(genders));
            }
            catch (Exception x)
            {
                _logger.LogException(x, $"GetAllGenders | :");
                return NotFound(new ApiResponse(500, x.Message));
            }
        }
    }
}
