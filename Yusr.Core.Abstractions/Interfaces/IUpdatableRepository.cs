using Yusr.Core.Abstractions.Entities;

namespace Yusr.Core.Abstractions.Interfaces
{
    public interface IUpdatableRepository<TEntity> where TEntity : BaseEntity
    {
        public Task UpdateAsync(TEntity entity);
    }
}
