using Application.Domain;
using Application.DTO.Dtos;
using Application.Entityframeworkcore.CompanyServices;
using Application.Entityframeworkcore.EmployeeServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestAssignment.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICompanyService _companyService;
        private readonly IEmployeeService _employeeService;
        public IndexModel(ILogger<IndexModel> logger, ICompanyService companyService, IEmployeeService employeeService)
        {
            _logger = logger;
            _companyService = companyService;
            _employeeService = employeeService;
        }
        [BindProperty]
        public List<CompanyDto> CompanyModel { get; set; }
        [BindProperty]
        public List<EmployeeDto> Employees { get; set; }
        public async void OnGet()
        {
            var employees = await _employeeService.GetListAsync();
            Employees = new List<EmployeeDto>();
            Employees = employees;
            CompanyModel = new List<CompanyDto>();
            CompanyModel = await _companyService.GetAllCompanies();
        }
    }
}