using Application.Models.User;

namespace Application.Abstractions.Services
{
    public interface IAccountService
    {
        Task RegisterUser(RegisterUser registerUser, CancellationToken cancellationToken);
        Task<string> LoginUser(LoginUser loginUser, CancellationToken cancellationToken);
    }
}
