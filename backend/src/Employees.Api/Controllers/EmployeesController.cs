using Employees.Application.Dto;
using Employees.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeesController(IEmployeeService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> GetAll(CancellationToken ct)
        {
            var employees = await _service.GetAllAsync(ct);
            return Ok(employees);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmployeeDto>> GetById(int id, CancellationToken ct)
        {
            var employee = await _service.GetByIdAsync(id, ct);
            return employee is null ? NotFound() : Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> Create(CreateEmployeeRequest request, CancellationToken ct)
        {
            var created = await _service.CreateAsync(request, ct);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateEmployeeRequest request, CancellationToken ct)
        {
            if (id != request.Id) return BadRequest("Route id and body id mismatch.");
            var success = await _service.UpdateAsync(request, ct);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var success = await _service.DeleteAsync(id, ct);
            return success ? NoContent() : NotFound();
        }
    }
}
