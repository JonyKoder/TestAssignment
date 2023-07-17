using Application.DTO.Dtos;
using Application.Entityframeworkcore.CompanyServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestAssignment.Pages
{
    public class Details : PageModel
    {
        private readonly ICompanyService _companyService;

        public Details(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [BindProperty]
        public CompanyDto Company { get; set; }
        public async void OnGetAsync(int id)
        {
            var dto = await _companyService.GetCompanyById(id);
            Company = dto;
        }

        public async Task<IActionResult> OnPostAsync()
        {
           await _companyService.UpdateCompany(Company.Id, Company);
           return RedirectToPage("/Index");
        }
    }
}
