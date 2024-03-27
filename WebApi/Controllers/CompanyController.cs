using Application.Abstractions;
using Application.Models.Company;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult> GetCompanies(CancellationToken cancellationToken)
        {
            var companies = await _companyService.GetAll(cancellationToken);

            return Ok(companies);
        }

        [HttpPost]
        public async Task<ActionResult> AddCompany(CreateCompany company, CancellationToken cancellationToken)
        {
            var result = await _companyService.AddCompany(company, cancellationToken);

           return Created(result.ToString(), null);
        }
    }
}
