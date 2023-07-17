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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            var res = _context.Companies.ToList();
            return res;
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _context.Companies.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Company> AddAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<Company> UpdateAsync(int id, Company company)
        {
            var existingCompany = await _context.Companies.FindAsync(id);
            if (existingCompany != null)
            {
                existingCompany.CompanyName = company.CompanyName;
                existingCompany.City = company.City;
                existingCompany.State = company.State;
                existingCompany.Phone = company.Phone;
                await _context.SaveChangesAsync();
            }
            return existingCompany;
        }

        public async Task DeleteAsync(int id)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == id);
            if (company != null)
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
            }
        }
    }
}
