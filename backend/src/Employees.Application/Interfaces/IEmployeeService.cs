using Employees.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllAsync(CancellationToken ct = default);
        Task<EmployeeDto?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<EmployeeDto> CreateAsync(CreateEmployeeRequest request, CancellationToken ct = default);
        Task<bool> UpdateAsync(UpdateEmployeeRequest request, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
