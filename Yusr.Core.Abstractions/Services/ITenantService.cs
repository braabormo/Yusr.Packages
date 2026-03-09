namespace Yusr.Core.Abstractions.Services
{
    public interface ITenantService
    {
        long? CurrentTenantId();
        void SetTenant(long tenantId);
    }
}
