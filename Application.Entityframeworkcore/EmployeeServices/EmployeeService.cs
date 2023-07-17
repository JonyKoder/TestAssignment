using Application.Domain;
using Application.DTO.Dtos;
using Application.Entityframeworkcore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entityframeworkcore.EmployeeServices
{
    
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        private EmployeeDto MapToDto(Employee company)
        {
            return new EmployeeDto(company.Id, company.CompanyId, company.FirstName, company.LastName, company.BithDate, company.Position);

        }

        private Employee MapToEntity(EmployeeDto companyDto)
        {
            return new Employee
            {
                Id = companyDto.Id,
                CompanyId = companyDto.EmployeeId,
                BithDate = companyDto.BithDate,
                FirstName = companyDto.FirstName,
                LastName = companyDto.LastName,
                Position = companyDto.Position,
            };
        }
        public async Task<List<EmployeeDto>> GetListByCompanyIdAsync(int companyId)
        {
            List<EmployeeDto> dto;
            dto = new List<EmployeeDto>();
            var res = await _employeeRepository.GetByCompanyIdAsync(companyId);
            foreach (var item in res)
            {
                dto.Add(MapToDto(item));
            }
           
            return dto;
        }

        public async Task<List<EmployeeDto>> GetListAsync()
        {
            List<EmployeeDto> dto;
            dto = new List<EmployeeDto>();
            var res = await _employeeRepository.GetAllEmployees();
            foreach (var item in res)
            {
                dto.Add(MapToDto(item));
            }

            return dto;
        }
    }
}
