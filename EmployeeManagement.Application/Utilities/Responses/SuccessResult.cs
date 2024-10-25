namespace EmployeeManagement.Application.Utilities.Responses;

public class SuccessResult : Result
{
    public SuccessResult(string message = null) : base(true, message) { }
}
