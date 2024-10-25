namespace EmployeeManagement.Application.Utilities.Responses;

public class ErrorDataResult<T> : DataResult<T>
{
    public ErrorDataResult(T data = default, string message = null) : base(data, false, message) { }
}
