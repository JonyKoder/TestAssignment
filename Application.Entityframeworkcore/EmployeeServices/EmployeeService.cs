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
                CompanyId = companyDto.CompanyId,
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

        public async Task<EmployeeDto> GetByIdAsync(int id)
        {
            var dto = await _employeeRepository.GetByIdAsync(id);
            var mapDto = MapToDto(dto);
            return mapDto;
        }

        public async Task<bool> Create(EmployeeDto dto)
        {
            var employee = await _employeeRepository.Create(dto);
            return employee != null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var res = await _employeeRepository.GetByIdAsync(id);
           
            return true;
        }

        public async Task<EmployeeDto> Update(EmployeeDto dto)
        {
            var employee = await _employeeRepository.GetByIdAsync(dto.Id);
            employee.Position = dto.Position;
            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.BithDate = dto.BithDate;
            employee.CompanyId = dto.CompanyId;

            var newDto = MapToDto(employee);
            await _employeeRepository.UpdateAsync(dto.Id, newDto);
            return newDto;
        }
        
    }
}
