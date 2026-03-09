using Yusr.Core.Abstractions.Primitives;

namespace Yusr.Application.Abstractions.Interfaces
{
    public interface IDeletableService
    {
        public Task<OperationResult<bool>> DeleteAsync(long id);
    }
}
