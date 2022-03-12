using Base.Core.Helpers;
using Base.Services.Implementation.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace barangay_assistance_api.Controllers
{
    [Route("api/user")]
    [ApiController]
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
    }
}
