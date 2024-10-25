namespace EmployeeManagement.Application.Utilities.Responses;

public interface IResult
{
    bool Success { get; }
    string Message { get; }
}
