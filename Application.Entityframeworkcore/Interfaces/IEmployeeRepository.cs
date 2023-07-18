using Application.Domain;
using Application.DTO.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entityframeworkcore.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployees();
        Task<List<Employee>> GetByCompanyIdAsync(int companyId);
        Task<Employee> GetByIdAsync(int Id);
        Task<Employee> Create(EmployeeDto dto);
        Task<Employee> UpdateAsync(int id, EmployeeDto employee);
    }
}
