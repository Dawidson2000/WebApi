using Application.Abstractions.Repositories;
using Application.Mapper;
using Application.Models.Company;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Services;
using Moq;

public class CompanyServiceTests
{
    private readonly Mock<ICompanyRepository> _mockCompanyRepository;
    private readonly CompanyService _companyService;

    public CompanyServiceTests()
    {
        _mockCompanyRepository = new Mock<ICompanyRepository>();

        var mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new CompanyMappingProfile());
        });
        var mapper = mockMapper.CreateMapper();

        _companyService = new CompanyService(_mockCompanyRepository.Object, mapper);
    }

    [Fact]
    public async Task GetAll_ShouldReturnAllCompanies()
    {
        // Arrange
        var companies = new List<CompanyEntity> { new CompanyEntity { Id = Guid.NewGuid(), Name = "Test", City = "TestCity" } };
        _mockCompanyRepository.Setup(repo => repo.GetAll(It.IsAny<CancellationToken>())).ReturnsAsync(companies);

        // Act
        var result = await _companyService.GetAll(CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task GetCompanyById_ShouldReturnCompany()
    {
        // Arrange
        var companyId = Guid.NewGuid();
        var company = new CompanyEntity { Id = companyId, Name = "Test", City = "TestCity" };
        _mockCompanyRepository.Setup(repo => repo.GetById(companyId, It.IsAny<CancellationToken>())).ReturnsAsync(company);

        // Act
        var result = await _companyService.GetCompanyById(companyId, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(companyId, result.Id);
    }

    [Fact]
    public async Task AddCompany_ShouldAddCompanyAndReturnId()
    {
        // Arrange
        var createCompany = new CreateCompany { Name = "Test", City = "TestCity" };
        var companyEntity = new CompanyEntity { Name = createCompany.Name, City = createCompany.City };
        _mockCompanyRepository.Setup(repo => repo.AddCompany(companyEntity, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        // Act
        var result = await _companyService.AddCompany(createCompany, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task UpdateCompany_ShouldUpdateCompany()
    {
        // Arrange
        var updateCompany = new UpdateCompany { Id = Guid.NewGuid(), Name = "Updated", City = "UpdatedCity" };
        var companyEntity = new CompanyEntity { Id = updateCompany.Id, Name = "OldName", City = "OldCity" };
        _mockCompanyRepository.Setup(repo => repo.GetById(updateCompany.Id, It.IsAny<CancellationToken>())).ReturnsAsync(companyEntity);
        _mockCompanyRepository.Setup(repo => repo.UpdateCompany(companyEntity, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        // Act
        var result = await _companyService.UpdateCompany(updateCompany, CancellationToken.None);

        // Assert
        Assert.Equal(updateCompany.Id, result);
        Assert.Equal(updateCompany.Name, companyEntity.Name);
        Assert.Equal(updateCompany.City, companyEntity.City);
    }

    [Fact]
    public async Task RemoveCompany_ShouldRemoveCompany()
    {
        // Arrange
        var companyId = Guid.NewGuid();
        var companyEntity = new CompanyEntity { Id = companyId, Name = "Test", City = "TestCity" };
        _mockCompanyRepository.Setup(repo => repo.GetById(companyId, It.IsAny<CancellationToken>())).ReturnsAsync(companyEntity);
        _mockCompanyRepository.Setup(repo => repo.RemoveCompany(companyEntity, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        // Act
        var result = await _companyService.RemoveCompany(companyId, CancellationToken.None);

        // Assert
        Assert.Equal(companyId, result);
    }
}
