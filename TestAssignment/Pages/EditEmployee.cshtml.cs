using Application.DTO.Dtos;
using Application.Entityframeworkcore.CompanyServices;
using Application.Entityframeworkcore.EmployeeServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestAssignment.Pages
{
    public class EditEmployeeModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        public EditEmployeeModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [BindProperty]
        public EmployeeDto Employee { get; set; }
        public async void OnGetAsync(int id)
        {
            var dto = await _employeeService.GetByIdAsync(id);
            Employee = dto;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _employeeService.Update(Employee);
            return RedirectToPage("/Index");
        }
    }
}
