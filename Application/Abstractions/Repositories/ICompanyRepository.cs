using Application.Models.Company;
using Domain.Entities;

namespace Application.Abstractions.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<CompanyEntity>> GetAll(CancellationToken cancellationToken);
        Task AddCompany(CompanyEntity company, CancellationToken cancellationToken);
        Task<CompanyEntity> GetById(Guid id, CancellationToken cancellationToken);
        Task UpdateCompany(CompanyEntity company, CancellationToken cancellationToken);
        Task RemoveCompany(CompanyEntity company, CancellationToken cancellationToken);
    }
}
