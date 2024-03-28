using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Models.User;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher<UserEntity> _passwordHasher;

        public AccountService(
            IMapper mapper, 
            IAccountRepository accountRepository,
            IPasswordHasher<UserEntity> passwordHasher)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task RegisterUser(RegisterUser user, CancellationToken cancellationToken) 
        {
            var userEntity = _mapper.Map<RegisterUser, UserEntity>(user);

            var hashedPassword = _passwordHasher.HashPassword(userEntity, user.Password);
            userEntity.Id = Guid.NewGuid();
            userEntity.PasswordHash = hashedPassword;

           await _accountRepository.CreateUser(userEntity, cancellationToken);
        }
    }
}
