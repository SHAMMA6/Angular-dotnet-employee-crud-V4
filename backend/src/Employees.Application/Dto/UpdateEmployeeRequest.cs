namespace Employees.Application.Dto
{
    public record UpdateEmployeeRequest(int Id, string FirstName, string LastName, string Email, string Position);
}
