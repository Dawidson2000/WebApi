using Application.Models.User;

namespace Application.Abstractions.Services
{
    public interface IAccountService
    {
        Task RegisterUser(RegisterUser user, CancellationToken cancellationToken);
    }
}
