using Application.Domain;
using Application.DTO.Dtos;
using Application.Entityframeworkcore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entityframeworkcore.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> Create(EmployeeDto dto)
        {
            var employee = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BithDate = dto.BithDate,
                Id = dto.Id,
                Position = dto.Position,
                CompanyId = dto.CompanyId
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            SeedEmployees(_context);
            var res = _context.Employees.ToList();
            return res;
        }

        public async Task<List<Employee>> GetByCompanyIdAsync(int companyId)
        {
            var res = await _context.Employees.Where(x => x.CompanyId == companyId).ToListAsync();
            return res;
        }

        public async Task<Employee> GetByIdAsync(int Id)
        {
            var employee = await _context.Employees.FindAsync(Id);
            return employee;
        }

        public async Task<Employee> UpdateAsync(int id, EmployeeDto employee)
        {
            var employeeFind = await _context.Employees.FindAsync(id);
            if (employeeFind != null)
            {
                employeeFind.FirstName = employee.FirstName;
                employeeFind.LastName = employee.LastName;
                employeeFind.BithDate = employee.BithDate;
                employeeFind.Position = employee.Position;
                employeeFind.CompanyId = employee.CompanyId;
            }
            _context.Employees.Update(employeeFind);
            return employeeFind;
        }
        public void SeedEmployees(ApplicationDbContext context)
        {
            var employees = new List<Employee>
              {
                new Employee { Id = 1, FirstName = "John", LastName = "Doe", BithDate = "01/01/1990", Position = "Manager", CompanyId = 1 },
                new Employee { Id = 2, FirstName = "Jane", LastName = "Smith", BithDate = "02/02/1991", Position = "Supervisor", CompanyId = 1 },
                new Employee { Id = 4, FirstName = "Soup", LastName = "First", BithDate = "03/03/1992", Position = "Employee", CompanyId = 2 },
                new Employee { Id = 5, FirstName = "Nick", LastName = "Second", BithDate = "03/03/1992", Position = "Employee", CompanyId = 3 },
                new Employee { Id = 6, FirstName = "Green", LastName = "One", BithDate = "03/03/1992", Position = "Employee", CompanyId = 3 }
              };

            foreach(var em in employees)
            {
                context.Employees.Add(em);
                context.SaveChangesAsync();
            }
            
        }
    }
}
