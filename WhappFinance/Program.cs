using Microsoft.EntityFrameworkCore;
using WhappFinance.Core.Data;
using WhappFinance.Core.Data.Repository.IRepository;
using WhappFinance.Core.Data.Repository;

namespace WhappFinance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            var connectionString = builder.Configuration.GetConnectionString("Connection");

            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
            
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.MapControllers();
            
            app.MapRazorPages();

            app.Run();
        }
    }
}
