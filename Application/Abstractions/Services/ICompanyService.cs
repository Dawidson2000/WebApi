using Application.Models.Company;
using Domain.Entities;
using System.Threading;

namespace Application.Abstractions.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyEntity>> GetAll(CancellationToken cancellationToken);
        Task<Guid> AddCompany(CreateCompany company, CancellationToken cancellationToken);
        Task<Guid> UpdateCompany(UpdateCompany company, CancellationToken cancellationToken);
        Task<CompanyEntity> GetCompanyById(Guid id, CancellationToken cancellationToken);
        Task<Guid> RemoveCompany(Guid id, CancellationToken cancellationToken);
    }
}
