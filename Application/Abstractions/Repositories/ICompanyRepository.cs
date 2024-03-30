﻿using Application.Models.Company;
using Domain.Entities;

namespace Application.Abstractions.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<CreateCompany>> GetAll(CancellationToken cancellationToken);
        Task AddCompany(CompanyEntity company, CancellationToken cancellationToken);
    }
}