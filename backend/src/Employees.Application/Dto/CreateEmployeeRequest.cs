namespace Employees.Application.Dto;

public record CreateEmployeeRequest(string FirstName, string LastName, string Email, string Position);
