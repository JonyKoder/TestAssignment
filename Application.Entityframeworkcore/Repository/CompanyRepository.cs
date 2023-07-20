using Application.Domain;
using Application.Entityframeworkcore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
            var random = new Random();
            var cities = new List<string> { "City 1", "City 2", "City 3", "City 4", "City 5" };
            var states = new List<string> { "State 1", "State 2", "State 3", "State 4", "State 5" };
            var addresses = new List<string> { "Address 1", "Address 2", "Address 3", "Address 4", "Address 5" };

            for (int i = 1; i <= 10; i++)
            {
                _context.Companies.Add(
                 new Company
                 {
                     Id = i,
                     CompanyName = $"Company {i}",
                     City = cities[random.Next(cities.Count)],
                     Address = addresses[random.Next(addresses.Count)],
                     State = states[random.Next(states.Count)],
                     Phone = $"{random.Next(1000000, 9999999)}"
                 });

            }
            _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
           
            var res = await _context.Companies.ToListAsync();
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
