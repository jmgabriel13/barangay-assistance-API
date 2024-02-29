using barangay_assistance_api.Helpers.Response;
using Base.Services.Helpers.Utility;
using Base.Services.Implementation.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace barangay_assistance_api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IAccount _login;

        private readonly Logger _logger = new();

        public AuthController(IAccount login)
        {
            _login = login;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult GetAccount([FromBody] UserLoginDTO userObj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiBadRequestResponse(ModelState));
            }

            try
            {
                var account = _login.GetAccount(userObj.Username, userObj.Password);

                if (account == null)
                    return BadRequest("User not found or invalid username/password.");

                return Ok(new ApiOkResponse(account));
            }
            catch (Exception x)
            {
                _logger.LogException(x, $"GetAccount (login) | userObj: {userObj}");
                return NotFound(new ApiResponse(500, x.Message));
            }
        }
    }
}
