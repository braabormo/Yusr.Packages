using Microsoft.Extensions.Logging;
using Yusr.Core.Abstractions.Primitives;
using Yusr.Core.Abstractions.Services;

namespace Yusr.Application.Abstractions.Services
{
    public abstract class BaseApplicationService(ILogger logger, IExceptionService exceptionService)
    {
        protected virtual string EntityName => "Entity";
        private readonly ILogger _logger = logger;
        private readonly IExceptionService _exceptionService = exceptionService;

        protected async Task<OperationResult<T>> ExecuteAsync<T>(
            Func<Task<OperationResult<T>>> action,
            Func<Task>? ifFailed = null,
            string? errorTitle = null) where T : new()
        {
            try
            {
                return await action();
            }
            catch (Exception ex)
            {
                if (ifFailed != null) await ifFailed();

                _logger.LogError(ex, "Failure in {Entity}: {Message}", EntityName, ex.Message);

                return _exceptionService.Map<T>(ex, EntityName, errorTitle);
            }
        }
    }
}