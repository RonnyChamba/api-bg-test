using ApiPruebaIntegrity.Exceptions;
using ApiPruebaIntegrity.Security.JwtUtils;
using System.Security.Claims;

namespace ApiPruebaIntegrity.Services.Impl
{
    public class SessionServiceImpl : ISessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionServiceImpl(IHttpContextAccessor httpContextAccessor) 
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public int RetrieveIdCompanySession()
        {

            var userLogin = RetriveClaimsPrincipal();

            var idCompany = JwtClaimsHelper.GetCompanyId(userLogin)
                ?? throw new BadCredentialException("A company was not found in session");

            return int.Parse(idCompany);
        }

        public ClaimsPrincipal RetriveClaimsPrincipal()
        {
            return _httpContextAccessor.HttpContext?.User
               ?? throw new BadCredentialException("A company was not found in session");
        }
    }
}
