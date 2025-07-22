using Employees.Application.Interfaces;
using Employees.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Infrastructure.Persistence
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _db;
        public EmployeeRepository(AppDbContext db) => _db = db;

        public Task<List<Employee>> GetAllAsync(CancellationToken ct = default) =>
            _db.Employees.AsNoTracking().OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ToListAsync(ct);

        public Task<Employee?> GetByIdAsync(int id, CancellationToken ct = default) =>
            _db.Employees.FirstOrDefaultAsync(e => e.Id == id, ct);

        public async Task<Employee> AddAsync(Employee employee, CancellationToken ct = default)
        {
            _db.Employees.Add(employee);
            await _db.SaveChangesAsync(ct);
            return employee;
        }

        public async Task UpdateAsync(Employee employee, CancellationToken ct = default)
        {
            _db.Employees.Update(employee);
            await _db.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Employee employee, CancellationToken ct = default)
        {
            _db.Employees.Remove(employee);
            await _db.SaveChangesAsync(ct);
        }

        public Task<bool> EmailExistsAsync(string email, int? excludingId = null, CancellationToken ct = default)
        {
            var query = _db.Employees.AsQueryable().Where(e => e.Email == email);
            if (excludingId.HasValue)
                query = query.Where(e => e.Id != excludingId.Value);
            return query.AnyAsync(ct);
        }
    }
}
