using Application.Abstractions.Repositories;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AccountRepository(AppDbContext context) : IAccountRepository
    {
        private readonly AppDbContext _context = context;
 
        public async Task CreateUser(UserEntity user, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<UserEntity> GetUser(string email, CancellationToken cancellationToken)
        {
            var userEntity = await _context.Users
               .FirstOrDefaultAsync(x => x.Email == email, cancellationToken);

            return userEntity;
        }
    }
}
