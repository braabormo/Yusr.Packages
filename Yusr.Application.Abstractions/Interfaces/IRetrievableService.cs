namespace Yusr.Packages.Application.Interfaces
{
    public interface IRetrievableService<TDto> where TDto : BaseDto, new()
    {
        public Task<OperationResult<TDto>> GetByIdAsync(long id);
    }
}
