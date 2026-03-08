namespace Yusr.Packages.Application.Interfaces
{
    public interface IBaseService<TDto> : IFilterableService<TDto>,
                                                IRetrievableService<TDto>,
                                                IAddableService<TDto>,
                                                IUpdatableService<TDto>,
                                                IDeletableService
        where TDto : BaseDto, new()
    {
    }
}
