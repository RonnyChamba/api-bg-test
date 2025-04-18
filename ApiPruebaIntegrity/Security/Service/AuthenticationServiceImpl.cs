using ApiPruebaIntegrity.Data;
using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;
using ApiPruebaIntegrity.Exceptions;
using ApiPruebaIntegrity.Models;
using ApiPruebaIntegrity.Security.DTOs;
using ApiPruebaIntegrity.Util;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaIntegrity.Security.Service
{
    public class AuthenticationServiceImpl : IAuthenticationService
    {
        private readonly ILogger<AuthenticationServiceImpl> _logger;
        private readonly DBContextTest _dbContextTest;
        private readonly IConfiguration _configuration;

        public AuthenticationServiceImpl(ILogger<AuthenticationServiceImpl> logger, DBContextTest dBContextTest, IConfiguration configuration)
        { 
            _logger = logger;
            _dbContextTest = dBContextTest;
            _configuration = configuration;
        }

        public async Task<GenericRespDTO<string>> AuthUser(GenericReqDTO<LoginReqDTO> reqDTO)
        {

            _logger.LogInformation("Req AuthUser: {}", reqDTO);

            var user  = await RetrieveUserByUsername(reqDTO.Payload.Username)
                        ?? throw new BadCredentialException("Bad credentials");

            if (!AuthUtil.VerifyPassword(reqDTO.Payload.Password, user.Password)) {
                throw new BadCredentialException("Bad credentials");
            }

            var jwtToken = AuthUtil.GenerateJwtToken(user, _configuration );

            return new GenericRespDTO<string>("OK", "Success Login", jwtToken);
        }

        private async Task<User?> RetrieveUserByUsername(string username)
        {

            return await _dbContextTest
                .Users
                .Include(u => u.Company)
                .Where(u => u.Username.Equals(username))
                .FirstOrDefaultAsync();
        }
    }
}
