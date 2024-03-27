using Application.Models.Company;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class CompanyMappingProfile : Profile
    {
        public CompanyMappingProfile() 
        {
            CreateMap<CompanyEntity, CreateCompany>();
            CreateMap<CreateCompany, CompanyEntity>();
        }
    }
}
