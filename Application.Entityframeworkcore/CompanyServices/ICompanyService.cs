using Application.DTO.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entityframeworkcore.CompanyServices
{
    public interface ICompanyService
    {
        Task<List<CompanyDto>> GetAllCompanies();
        Task<CompanyDto> GetCompanyById(int companyId);
        Task<CompanyDto> CreateCompany(CompanyDto companyDto);
        Task<CompanyDto> UpdateCompany(int companyId, CompanyDto updatedCompanyDto);
        Task DeleteCompany(int companyId);
    }
}
