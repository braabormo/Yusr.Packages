namespace Yusr.Packages.Application.Interfaces
{
    public interface IUpdatableService<TDto> where TDto : BaseDto, new()
    {
        public Task<OperationResult<TDto>> UpdateAsync(TDto dto);
    }
}