namespace Yusr.Core.Abstractions.Entities
{
    public class BaseTenantEntity : BaseEntity
    {
        public long TenantId { get; set; }

        public virtual ITenant Tenant { get; set; } = null!;
    }
}
