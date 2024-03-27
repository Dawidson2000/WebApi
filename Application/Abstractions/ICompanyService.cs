﻿using Application.Models.Company;
using System.Threading;

namespace Application.Abstractions
{
    public interface ICompanyService
    {
        Task<IEnumerable<CreateCompany>> GetAll(CancellationToken cancellationToken);
        Task<Guid> AddCompany(CreateCompany company, CancellationToken cancellationToken);
    }
}
