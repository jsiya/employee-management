using AutoMapper;
using EmployeeManagement.Application.DTOs.CompanyDTOs;
using EmployeeManagement.Application.DTOs.DepartmentDTOs;
using EmployeeManagement.Application.DTOs.EmployeeDTOs;
using EmployeeManagement.Application.Features.Companies.Commands.CreateCompany;
using EmployeeManagement.Application.Features.Companies.Commands.UpdateCompanyById;
using EmployeeManagement.Application.Features.Departments.Commands.CreateDepartment;
using EmployeeManagement.Application.Features.Departments.Commands.UpdateDepartment;
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

        CreateMap<CreateDepartmentCommandRequest, Department>();
        CreateMap<UpdateDepartmentCommandRequest, Department>();
        CreateMap<Department, DepartmentDto>()
            .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company));
        
        CreateMap<Employee, EmployeeDto>()
            .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department));
    }
}