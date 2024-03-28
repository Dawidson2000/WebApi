using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class AccountRepository(AppDbContext context) : IAccountRepository
    {
        private readonly AppDbContext _context = context;

        public async Task CreateUser(UserEntity user, CancellationToken cancellationToken) 
        {
           await _context.AddAsync(user, cancellationToken);
        }
    }
}
