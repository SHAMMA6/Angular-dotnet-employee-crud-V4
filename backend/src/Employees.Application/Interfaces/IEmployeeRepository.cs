using Employees.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync(CancellationToken ct = default);
        Task<Employee?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<Employee> AddAsync(Employee employee, CancellationToken ct = default);
        Task UpdateAsync(Employee employee, CancellationToken ct = default);
        Task DeleteAsync(Employee employee, CancellationToken ct = default);
        Task<bool> EmailExistsAsync(string email, int? excludingId = null, CancellationToken ct = default);
    }
}
