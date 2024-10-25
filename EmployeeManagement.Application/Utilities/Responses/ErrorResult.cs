namespace EmployeeManagement.Application.Utilities.Responses;

public class ErrorResult : Result
{
    public ErrorResult(string message = null) : base(false, message) { }
}
