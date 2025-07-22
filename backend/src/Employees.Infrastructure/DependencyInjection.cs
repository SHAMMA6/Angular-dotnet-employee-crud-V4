using Employees.Application.Interfaces;
using Employees.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Employees.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            var conn = config.GetConnectionString("DefaultConnection") ?? "Data Source=employees.db"; 
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(conn));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            return services;
        }
    }
}
