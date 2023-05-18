using System.Security.Claims;

namespace Portfel.Application.UserContext
{
    public interface IUserContext
    {
        int? GetUserId { get; }
        ClaimsPrincipal User { get; }
    }
}