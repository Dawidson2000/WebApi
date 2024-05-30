using Application.Abstractions.Services;
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

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCompany(Guid id, CancellationToken cancellationToken)
        {
            var company = await _companyService.GetCompanyById(id, cancellationToken);

            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult> AddCompany(CreateCompany company, CancellationToken cancellationToken)
        {
            var result = await _companyService.AddCompany(company, cancellationToken);

           return Created(result.ToString(), null);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCompany(UpdateCompany company, CancellationToken cancellationToken)
        {
            var result = await _companyService.UpdateCompany(company, cancellationToken);

            return Ok(result.ToString());
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(Guid id, CancellationToken cancellationToken)
        {
            await _companyService.RemoveCompany(id, cancellationToken);

            return NoContent();
        }

    }
}
