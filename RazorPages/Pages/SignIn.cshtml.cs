using Application.Abstractions.Services;
using Application.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages
{
    public class SignInModel : PageModel
    {
        private readonly IAccountService _accountService;

        public SignInModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public RegisterUser RegisterUser { get; set; }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            await _accountService.RegisterUser(RegisterUser, cancellationToken);

            return RedirectToPage();
        }

    }
}
