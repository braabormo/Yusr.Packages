
using Yusr.Core.Abstractions.Primitives;

namespace Yusr.Core.Abstractions.Services
{
    public interface IExceptionService
    {
        OperationResult<T> Map<T>(Exception ex, string entityName, string? errorTitle = null);
    }
}
