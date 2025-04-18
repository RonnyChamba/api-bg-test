using ApiPruebaIntegrity.Util;
using System.Security.Claims;

namespace ApiPruebaIntegrity.Security.JwtUtils
{
    public class JwtClaimsHelper
    {
        public static string? GetUserId(ClaimsPrincipal user) =>
       user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        public static string? GetUsername(ClaimsPrincipal user) =>
            user.FindFirst(ClaimTypes.Name)?.Value;

        public static string? GetRole(ClaimsPrincipal user) =>
            user.FindFirst(ClaimTypes.Role)?.Value;

        public static string? GetCompanyId(ClaimsPrincipal user) =>
            user.FindFirst(IntegrityApiConstants.NameClaimsCompany)?.Value;
    }
}
