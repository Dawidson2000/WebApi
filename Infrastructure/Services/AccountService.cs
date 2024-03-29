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
        private readonly IJwtTokenService _jwtTokenService;

        public AccountService(
            IMapper mapper,
            IAccountRepository accountRepository,
            IPasswordHasher<UserEntity> passwordHasher,
            IJwtTokenService jwtTokenService)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenService = jwtTokenService;
        }

        public async Task RegisterUser(RegisterUser registerUser, CancellationToken cancellationToken) 
        {
            var userEntity = _mapper.Map<RegisterUser, UserEntity>(registerUser);

            var hashedPassword = _passwordHasher.HashPassword(userEntity, registerUser.Password);
            userEntity.Id = Guid.NewGuid();
            userEntity.PasswordHash = hashedPassword;

           await _accountRepository.CreateUser(userEntity, cancellationToken);
        }

        public async Task<string> LoginUser(LoginUser loginUser, CancellationToken cancellationToken) 
        {
            var user = await _accountRepository.GetUser(loginUser.Email, cancellationToken);

            if (user == null)
            {
                throw new Exception("Invalid email or password");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginUser.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new Exception("Invalid email or password");
            }

            var token = _jwtTokenService.GenerateToken(user);
            
            return token;
        }
    }
}
