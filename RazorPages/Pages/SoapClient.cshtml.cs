using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SoapService;

namespace RazorPages.Pages
{
    public class SOAPClientModel : PageModel
    {
        public string SoapResult = string.Empty;

        [BindProperty]
        public SoapService.User User { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            IUserService soapServiceChannel = new UserServiceClient(UserServiceClient.EndpointConfiguration.BasicHttpBinding_IUserService);
            var registerUserResponse = soapServiceChannel.RegisterUserAsync(new SoapService.User()
            {
                FirstName = User.FirstName,
                LastName = User.LastName,
                EmailAddress = User.EmailAddress,
                Age = User.Age,
                MarketingConsent = true
            }).Result;

            SoapResult = registerUserResponse;
            return Page();
        }
    }
}
