using Application.DTO.Dtos;
using Application.Entityframeworkcore.CompanyServices;
using Application.Entityframeworkcore.EmployeeServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestAssignment.Pages
{
    public class Details : PageModel
    {
        private readonly ICompanyService _companyService;
        private readonly IEmployeeService _employeeService;
        public Details(ICompanyService companyService, IEmployeeService employeeService)
        {
            _companyService = companyService;
            _employeeService = employeeService;
        }
        [BindProperty]
        public CompanyDto Company { get; set; }
        [BindProperty]
        public List<EmployeeDto> Employees { get; set; }
        public async void OnGetAsync(int id)
        {
            var dto = await _companyService.GetCompanyById(id);
            Company = dto;
            var employees = await _employeeService.GetListByCompanyIdAsync(Company.Id);
            Employees = employees;
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
           await _companyService.UpdateCompany(Company.Id, Company);
           return RedirectToPage("/Index");
        }
    }
}
