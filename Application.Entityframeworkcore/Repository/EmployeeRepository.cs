using Application.Domain;
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

        public async Task<List<Employee>> GetAllEmployees()
        {
            var res = _context.Employees.ToList();
            return res;
        }

        public async Task<List<Employee>> GetByCompanyIdAsync(int companyId)
        {
            var res = await _context.Employees.Where(x => x.CompanyId == companyId).ToListAsync();
            return res;
        }
    }
}
