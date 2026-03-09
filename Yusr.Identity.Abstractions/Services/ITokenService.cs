using System.Security.Claims;

namespace Yusr.Identity.Abstractions.Services
{
    public interface ITokenService
    {
        string GenerateToken(IEnumerable<Claim> claims);
    }
}
