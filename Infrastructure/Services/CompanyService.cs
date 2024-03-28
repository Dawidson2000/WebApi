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

        public async Task<IEnumerable<CreateCompany>> GetAll(CancellationToken cancellationToken)
        {
            return await _companyRepository.GetAll(cancellationToken);
        }


        public async Task<Guid> AddCompany(CreateCompany company, CancellationToken cancellationToken)
        {
            var newCompanyEntity = _mapper.Map<CreateCompany, CompanyEntity>(company);
            newCompanyEntity.Id = Guid.NewGuid();

            await _companyRepository.AddCompany(newCompanyEntity, cancellationToken);

            return newCompanyEntity.Id;
        }
    }
}
