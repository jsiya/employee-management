using AutoMapper;
using EmployeeManagement.Application.DTOs.CompanyDTOs;
using EmployeeManagement.Application.Features.Companies.Commands.CreateCompany;
using EmployeeManagement.Application.Features.Companies.Commands.UpdateCompanyById;
using EmployeeManagement.Domain.Entities.Concretes;

namespace EmployeeManagement.Application.Utilities.Profiles;

public class Mapper: Profile
{
    public Mapper()
    {
        CreateMap<Company, CompanyDto>();
        CreateMap<CompanyDto, Company>();

        CreateMap<CreateCompanyCommandRequest, Company>();
        CreateMap<UpdateCompanyCommandRequest, Company>();
    }
}