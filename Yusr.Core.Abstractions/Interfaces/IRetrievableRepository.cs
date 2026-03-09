using Yusr.Core.Abstractions.Entities;

namespace Yusr.Core.Abstractions.Interfaces
{
    public interface IRetrievableRepository<TEntity> where TEntity : BaseEntity
    {
        public Task<TEntity?> GetByIdAsync(long id, bool track = false);
    }
}
