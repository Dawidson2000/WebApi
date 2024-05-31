using Application.Models.User;
using Domain.Entities;

namespace Application.Abstractions.Services
{
    public interface IAccountService
    {
        Task RegisterUser(RegisterUser registerUser, CancellationToken cancellationToken);
        Task<string> LoginUser(LoginUser loginUser, CancellationToken cancellationToken);
        Task<Guid> UpdateUser(UserEntity user, CancellationToken cancellationToken);
        Task RemoveUser(string email, CancellationToken cancellationToken);
        Task<IEnumerable<UserEntity>> GetAll(CancellationToken cancellationToken);
        Task<UserEntity> GetUserByEmail(string email, CancellationToken cancellationToken);
    }
}
