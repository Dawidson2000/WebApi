using Application.Abstractions.Repositories;
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

        public async Task<IEnumerable<CompanyEntity>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Companies
                .ToListAsync(cancellationToken);
        }

        public async Task<CompanyEntity> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Companies
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync(cancellationToken);
        }

        public async Task AddCompany(CompanyEntity company, CancellationToken cancellationToken) 
        {
            await _context.Companies.AddAsync(company, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateCompany(CompanyEntity company, CancellationToken cancellationToken)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveCompany(CompanyEntity company, CancellationToken cancellationToken)
        {
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
