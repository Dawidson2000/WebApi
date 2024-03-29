using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Domain.Entities;
using Infrastructure.Authentication;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => 
                options.UseInMemoryDatabase(configuration.GetConnectionString("DefaultConnection")));

            services.AddJwtAuthentication(configuration);
            services.AddScoped<IPasswordHasher<UserEntity>, PasswordHasher<UserEntity>>();
            
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();

            return services;
        }
    }
}
