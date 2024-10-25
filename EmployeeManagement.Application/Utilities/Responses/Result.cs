namespace EmployeeManagement.Application.Utilities.Responses;

public class Result : IResult
{
    public bool Success { get; }
    public string Message { get; }

    public Result(bool success, string message = null)
    {
        Success = success;
        Message = message;
    }
}
