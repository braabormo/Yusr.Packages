namespace Yusr.Packages.Application.Interfaces
{
    public interface IDeletableService
    {
        public Task<OperationResult<bool>> DeleteAsync(long id);
    }
}
