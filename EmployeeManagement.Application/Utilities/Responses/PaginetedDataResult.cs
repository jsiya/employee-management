namespace EmployeeManagement.Application.Utilities.Responses;

public class PaginatedDataResult<T> : DataResult<object>
{
    public PaginatedDataResult(IEnumerable<T> items, int totalCount, int pageSize, int pageNumber, bool hasNext, bool hasPrevious)
        : base(new
        {
            items = items,
            totalCount = totalCount,
            pageSize = pageSize,
            pageNumber = pageNumber,
            hasNext = hasNext,
            hasPrevious = hasPrevious
        }, true)
    { }
}
