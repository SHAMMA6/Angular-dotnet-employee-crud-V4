using Employees.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employees.Infrastructure.Persistence
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(AppDbContext db)
        {
            await db.Database.MigrateAsync();

            if (!await db.Employees.AnyAsync())
            {
                db.Employees.AddRange(new[]
                {
                new Employee { FirstName = "Yousef", LastName = "Abdel-Fattah", Email = "yousef@example.com", Position = "Backend Developer" },
                new Employee { FirstName = "Shahd", LastName = "Ali", Email = "shahd@example.com", Position = "QA Analyst" },
                new Employee { FirstName = "Ahmed", LastName = "Noor", Email = "ahmad@example.com", Position = "HR" }
            });
                await db.SaveChangesAsync();
            }
        }
    }
}
