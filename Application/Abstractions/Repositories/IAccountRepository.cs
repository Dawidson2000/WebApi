using Domain.Entities;

namespace Application.Abstractions.Repositories
{
    public interface IAccountRepository
    {
        Task CreateUser(UserEntity user, CancellationToken cancellationToken);
    }
}
