namespace Yusr.Packages.Application.Interfaces
{
    public interface IAddableService<TDto> where TDto : BaseDto, new()
    {
        public Task<OperationResult<TDto>> AddAsync(TDto dto);
    }
}
