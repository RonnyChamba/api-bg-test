using ApiPruebaIntegrity.Data;
using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;
using ApiPruebaIntegrity.Exceptions;
using ApiPruebaIntegrity.Models;
using ApiPruebaIntegrity.Security.JwtUtils;
using ApiPruebaIntegrity.Util;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace ApiPruebaIntegrity.Services.Impl
{
    public class UserServiceImpl : IUserService
    {
        private readonly ILogger<UserServiceImpl> _logger;
        private readonly IMapper _mapper;
        private readonly DBContextTest _dBContextTest;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserServiceImpl(ILogger<UserServiceImpl> logger, IMapper mapper, DBContextTest dBContextTest, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _mapper = mapper;
            _dBContextTest = dBContextTest;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<GenericRespDTO<bool>> ExistUserByUsername(GenericReqDTO<string> reqDTO)
        {
            _logger.LogInformation("Req ExistUserByUsername(): {}", reqDTO);

            var isExists =  await _dBContextTest.Users.AnyAsync(user => user.Username.Equals(reqDTO.Payload));

            return new GenericRespDTO<bool>("OK", "Transaction successfully processed", isExists);
        }

        public async Task<GenericRespDTO<string>> SaveCompany(GenericReqDTO<CompanyReqDTO> reqDTO)
        {
            _logger.LogInformation("Req SaveCompany() {}", reqDTO);

            await ValidUsernameExists(reqDTO.Payload.UserReqDTO.Username);

            var companyModel = _mapper.Map<Company>(reqDTO.Payload);
            var userModel = _mapper.Map<User>(reqDTO.Payload.UserReqDTO);

            userModel.Company = companyModel;
            userModel.Password = AuthUtil.HashPassword(userModel.Password);
            await _dBContextTest.Users.AddAsync(userModel);
            await _dBContextTest.SaveChangesAsync();


            return new GenericRespDTO<string>("OK", "Company create succcess", "");
        }

        public async Task<GenericRespDTO<string>> SaveUser(GenericReqDTO<UserReqDTO> reqDTO)
        {
            _logger.LogInformation("Req SaveUser: {}", reqDTO);

            await ValidUsernameExists(reqDTO.Payload.Username);

            var userModel = GenerateUserModel(reqDTO.Payload);

            await _dBContextTest.Users.AddAsync(userModel);
            await _dBContextTest.SaveChangesAsync();

            return new GenericRespDTO<string>("OK", "User create succcess", "");
        }

        private User GenerateUserModel(UserReqDTO userReqDTO) 
        {
            var userModel = _mapper.Map<User>(userReqDTO);
            userModel.Rol = IntegrityApiConstants.NameRolUser;

            var userLogin = RetriveClaimsPrincipal();

            var idCompany = JwtClaimsHelper.GetCompanyId(userLogin)
                ?? throw new BadCredentialException("A company was not found in session");

            userModel.CompanyId = int.Parse(idCompany);
            userModel.Password = AuthUtil.HashPassword(userModel.Password);

            return userModel;

        }
        private ClaimsPrincipal RetriveClaimsPrincipal() {

            return _httpContextAccessor.HttpContext?.User
               ?? throw new BadCredentialException("A company was not found in session");
        }

        private async Task ValidUsernameExists(string username) {

            var genericResp = await ExistUserByUsername(new GenericReqDTO<string>("Api", username));

            if (genericResp.Data) { 
                
                throw new ConflictException($"Username {username} already exists");
            }
        }
    }
}
