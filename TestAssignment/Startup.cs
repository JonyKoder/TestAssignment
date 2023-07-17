using Application.Entityframeworkcore;
using Application.Entityframeworkcore.CompanyServices;
using Application.Entityframeworkcore.Interfaces;
using Application.Entityframeworkcore.Repository;
using Microsoft.EntityFrameworkCore;

namespace TestAssignment
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("PostgresConnection")));

          
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // Настройка конвейера обработки HTTP-запросов
        }
    }
}
