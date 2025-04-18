using System.Security.Claims;

namespace ApiPruebaIntegrity.Services
{
    public interface ISessionService
    {
        ClaimsPrincipal RetriveClaimsPrincipal();

        int RetrieveIdCompanySession();
    }    
}
