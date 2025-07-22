using AutoMapper;
using Employees.Application.Dto;
using Employees.Application.Interfaces;
using Employees.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        private readonly IValidator<CreateEmployeeRequest> _createValidator;
        private readonly IValidator<UpdateEmployeeRequest> _updateValidator;
        private readonly IMapper _mapper;

        public EmployeeService(
            IEmployeeRepository repo,
            IValidator<CreateEmployeeRequest> createValidator,
            IValidator<UpdateEmployeeRequest> updateValidator,
            IMapper mapper)
        {
            _repo = repo;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDto>> GetAllAsync(CancellationToken ct = default)
        {
            var entities = await _repo.GetAllAsync(ct);
            return _mapper.Map<List<EmployeeDto>>(entities);
        }

        public async Task<EmployeeDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            return entity is null ? null : _mapper.Map<EmployeeDto>(entity);
        }

        public async Task<EmployeeDto> CreateAsync(CreateEmployeeRequest request, CancellationToken ct = default)
        {
            await _createValidator.ValidateAndThrowAsync(request, ct);

            // Unique email rule (demo-level)
            if (await _repo.EmailExistsAsync(request.Email, null, ct))
                throw new ValidationException($"Email '{request.Email}' already exists.");

            var entity = _mapper.Map<Employee>(request);
            var created = await _repo.AddAsync(entity, ct);
            return _mapper.Map<EmployeeDto>(created);
        }

        public async Task<bool> UpdateAsync(UpdateEmployeeRequest request, CancellationToken ct = default)
        {
            await _updateValidator.ValidateAndThrowAsync(request, ct);
            var entity = await _repo.GetByIdAsync(request.Id, ct);
            if (entity is null) return false;

            if (await _repo.EmailExistsAsync(request.Email, request.Id, ct))
                throw new ValidationException($"Email '{request.Email}' already exists.");

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Email = request.Email;
            entity.Position = request.Position;

            await _repo.UpdateAsync(entity, ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity is null) return false;
            await _repo.DeleteAsync(entity, ct);
            return true;
        }
    }
}
