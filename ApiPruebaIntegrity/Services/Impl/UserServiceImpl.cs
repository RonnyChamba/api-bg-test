using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;

namespace ApiPruebaIntegrity.Services.Impl
{
    public class UserServiceImpl : IUserService
    {
        private readonly ILogger<UserServiceImpl> _logger;

        public UserServiceImpl(ILogger<UserServiceImpl> logger)
        {
            _logger = logger;
        }

        public GenericRespDTO<string> SaveCompany(GenericReqDTO<CompanyReqDTO> reqDTO)
        {
            _logger.LogInformation("Req SaveCompany() {}", reqDTO);
            throw new NotImplementedException();
        }
    }
}
