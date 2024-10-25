namespace EmployeeManagement.Application.Utilities.Responses;

public interface IDataResult<T> : IResult
{
    T Data { get; }
}
