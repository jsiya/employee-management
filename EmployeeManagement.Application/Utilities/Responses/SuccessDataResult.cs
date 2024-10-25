namespace EmployeeManagement.Application.Utilities.Responses;

public class SuccessDataResult<T> : DataResult<T>
{
    public SuccessDataResult(T data, string message = null) : base(data, true, message) { }
}
