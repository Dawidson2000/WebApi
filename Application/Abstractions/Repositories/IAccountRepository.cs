using Application.Models.User;
using Domain.Entities;

namespace Application.Abstractions.Repositories
{
    public interface IAccountRepository
    {
        Task CreateUser(UserEntity user, CancellationToken cancellationToken);
        Task<UserEntity> GetUser(string email, CancellationToken cancellationToken);
    }
}
