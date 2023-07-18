using Application.Domain;
using Application.DTO.Dtos;
using Application.Entityframeworkcore.Interfaces;

namespace Application.Entityframeworkcore.CompanyServices
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<List<CompanyDto>> GetAllCompanies()
        {
            var companies = await _companyRepository.GetAllAsync();
            var companyDtos = companies.Select(c => MapToDto(c)).ToList();
            return companyDtos;
        }

        public async Task<CompanyDto> GetCompanyById(int companyId)
        {
            var company = await _companyRepository.GetByIdAsync(companyId);
            var companyDto = MapToDto(company);
            return companyDto;
        }

        public async Task<CompanyDto> CreateCompany(CompanyDto companyDto)
        {
            var company = MapToEntity(companyDto);
            var createdCompany = await _companyRepository.AddAsync(company);
            var createdCompanyDto = MapToDto(createdCompany);
            return createdCompanyDto;
        }

        public async Task<CompanyDto> UpdateCompany(int companyId, CompanyDto updatedCompanyDto)
        {
            var updatedCompany = MapToEntity(updatedCompanyDto);
            updatedCompany = await _companyRepository.UpdateAsync(companyId, updatedCompany);
            updatedCompanyDto = MapToDto(updatedCompany);
            return updatedCompanyDto;
        }

        public async Task DeleteCompany(int companyId)
        {
            await _companyRepository.DeleteAsync(companyId);
        }

        private CompanyDto MapToDto(Company company)
        {
            return new CompanyDto(company.Id, company.CompanyName, company.City, company.State, company.Phone, company.Address);
           
        }

        private Company MapToEntity(CompanyDto companyDto)
        {
            return new Company
            {
                Id = companyDto.Id,
                CompanyName = companyDto.Name,
                City = companyDto.City,
                Phone = companyDto.Phone,
                State = companyDto.State,
                Address = companyDto.Address
            };
        }
    }
}
