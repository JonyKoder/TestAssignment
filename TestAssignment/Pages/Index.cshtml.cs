using Application.Entityframeworkcore.CompanyServices;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestAssignment.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICompanyService _companyService;
        public IndexModel(ILogger<IndexModel> logger, ICompanyService companyService)
        {
            _logger = logger;
            _companyService = companyService;
        }


        public async void OnGet()
        {
   
        }
    }
}