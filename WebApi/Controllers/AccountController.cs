using Application.Abstractions.Services;
using Application.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController(IAccountService accountService) : Controller
    {
        private readonly IAccountService _accountService = accountService;

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser(RegisterUser user, CancellationToken cancellationToken)
        {
            await _accountService.RegisterUser(user, cancellationToken);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<string>> LoginUser(LoginUser user, CancellationToken cancellationToken) 
        {
            var token = await _accountService.LoginUser(user, cancellationToken);
            return Ok(token);
        }
    }
}
