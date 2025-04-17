using ApiPruebaIntegrity.Data;
using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;
using ApiPruebaIntegrity.Models;
using AutoMapper;

namespace ApiPruebaIntegrity.Services.Impl
{
    public class UserServiceImpl : IUserService
    {
        private readonly ILogger<UserServiceImpl> _logger;
        private readonly IMapper _mapper;
        private readonly DBContextTest _dBContextTest;

        public UserServiceImpl(ILogger<UserServiceImpl> logger, IMapper mapper, DBContextTest dBContextTest)
        {
            _logger = logger;
            _mapper = mapper;
            _dBContextTest = dBContextTest;
        }

        public async Task<GenericRespDTO<string>> SaveCompany(GenericReqDTO<CompanyReqDTO> reqDTO)
        {
            _logger.LogInformation("Req SaveCompany() {}", reqDTO);

            var companyModel = _mapper.Map<Company>(reqDTO.Payload);
            var userModel = _mapper.Map<User>(reqDTO.Payload.UserReqDTO);

            userModel.Company = companyModel;
            await _dBContextTest.Users.AddAsync(userModel);
            await _dBContextTest.SaveChangesAsync();


            return new GenericRespDTO<string>("OK", "Company create succcess", "");
        }
    }
}
