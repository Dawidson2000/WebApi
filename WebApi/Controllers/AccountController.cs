using Application.Abstractions.Services;
using Application.Models.User;
using Domain.Entities;
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
        
        [HttpGet]
        public async Task<ActionResult> GetUsers(CancellationToken cancellationToken)
        {
            var companies = await _accountService.GetAll(cancellationToken);

            return Ok(companies);
        }

        [HttpGet("{email}")]
        public async Task<ActionResult> Getuser(string email, CancellationToken cancellationToken)
        {
            var company = await _accountService.GetUserByEmail(email, cancellationToken);

            return Ok(company);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(UserEntity user, CancellationToken cancellationToken)
        {
            var result = await _accountService.UpdateUser(user, cancellationToken);

            return Ok(result.ToString());
        }

        [HttpDelete("{email}")]
        public async Task<ActionResult> DeleteCompany(string email, CancellationToken cancellationToken)
        {
            await _accountService.RemoveUser(email, cancellationToken);

            return NoContent();
        }

    }
}
