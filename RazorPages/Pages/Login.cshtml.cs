using Application.Abstractions.Services;
using Application.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAccountService _accountService;

        public LoginModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public LoginUser LoginUser { get; set; }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            var token = await _accountService.LoginUser(LoginUser, cancellationToken);

            return RedirectToPage("Index");
        }

    }
}
