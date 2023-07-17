
using Application.Entityframeworkcore;
using Application.Entityframeworkcore.CompanyServices;
using Application.Entityframeworkcore.EmployeeServices;
using Application.Entityframeworkcore.Interfaces;
using Application.Entityframeworkcore.Repository;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public IConfiguration Configuration { get; }
    public Program(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
      
        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
               options.UseNpgsql("Host=localhost;Port=5432;Database=AssingmentDb;User ID=root;Password=myPassword;Include Error Detail=true;"));

        builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
        builder.Services.AddTransient<ICompanyService, CompanyService>();
        builder.Services.AddTransient<IEmployeeService, EmployeeService>();
        builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

       

        app.Run();
       

    }

   
}

