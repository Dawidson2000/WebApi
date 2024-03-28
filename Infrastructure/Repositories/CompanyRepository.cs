using Application.Abstractions;
using Application.Models.Company;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CompanyRepository(AppDbContext context, IMapper mapper) : ICompanyRepository
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<CreateCompany>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Companies
                .ProjectTo<CreateCompany>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        public async Task AddCompany(CompanyEntity company, CancellationToken cancellationToken) 
        {
            await _context.Companies.AddAsync(company, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
