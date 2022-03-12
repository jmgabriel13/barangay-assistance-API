using Base.Core.Helpers;
using Base.Services.Implementation.Account;
using Microsoft.AspNetCore.Mvc;
using System;

namespace barangay_assistance_api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccount _login;

        public AuthController(IAccount login)
        {
            _login = login;
        }

        [HttpPost("login")]
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
                    return BadRequest();

                return Ok(new ApiOkResponse(account));
            }
            catch (Exception x)
            {
                return NotFound(new ApiResponse(500, x.Message));
            }
        }
    }
}
