namespace Yusr.Packages.Application.Interfaces
{
    public interface IFilterableService<TDto> where TDto : BaseDto
    {
        public Task<OperationResult<FilterResponse<TDto>>> FilterAsync(int pageNumber, int rowsPerPage, FilterCondition? condition);
    }
}
