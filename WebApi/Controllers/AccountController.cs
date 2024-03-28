using Application.Abstractions.Services;
using Application.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController(IAccountService accountService) : Controller
    {
        private readonly IAccountService _accountService = accountService;

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser(RegisterUser user, CancellationToken cancellationToken) 
        {
            await _accountService.RegisterUser(user, cancellationToken);
            return Ok();
        }
    }
}
