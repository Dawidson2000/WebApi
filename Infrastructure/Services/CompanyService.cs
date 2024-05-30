using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Models.Company;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompanyEntity>> GetAll(CancellationToken cancellationToken)
        {
            return await _companyRepository.GetAll(cancellationToken);
        }

        public async Task<CompanyEntity> GetCompanyById(Guid id, CancellationToken cancellationToken)
        {
            return await _companyRepository.GetById(id, cancellationToken);
        }

        public async Task<Guid> AddCompany(CreateCompany company, CancellationToken cancellationToken)
        {
            var newCompanyEntity = _mapper.Map<CreateCompany, CompanyEntity>(company);
            newCompanyEntity.Id = Guid.NewGuid();

            await _companyRepository.AddCompany(newCompanyEntity, cancellationToken);

            return newCompanyEntity.Id;
        }
        
        public async Task<Guid> UpdateCompany(UpdateCompany company, CancellationToken cancellationToken)
        {
            var companyToUpdate = await _companyRepository.GetById(company.Id, cancellationToken);

            companyToUpdate.Name = company.Name;
            companyToUpdate.City = company.City;

            await _companyRepository.UpdateCompany(companyToUpdate, cancellationToken);

            return companyToUpdate.Id;
        }

        public async Task<Guid> RemoveCompany(Guid id, CancellationToken cancellationToken)
        {
            var companyToRemove = await _companyRepository.GetById(id, cancellationToken);

            await _companyRepository.RemoveCompany(companyToRemove, cancellationToken);

            return id;
        }

    }
}
