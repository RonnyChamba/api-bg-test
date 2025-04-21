using ApiPruebaIntegrity.Data;
using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;
using ApiPruebaIntegrity.Exceptions;
using ApiPruebaIntegrity.Models;
using ApiPruebaIntegrity.Security.JwtUtils;
using ApiPruebaIntegrity.Util;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<GenericRespDTO<List<UserRespDTO>>> FindAllUsers(string name)
        {
            _logger.LogInformation("Filter Name: {}", name);

            var idCompany = RetrieveIdCompanySession();

            var query = _dBContextTest.Users
                        .Where(user => user.CompanyId == idCompany && 
                               user.Status.Equals(IntegrityApiConstants.StatusActive));

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(user => user.Names.Contains(name) || user.LasName.Contains(name));
            }

            var listUsers = await query.ToListAsync();
            var userListDTO = _mapper.Map<List<UserRespDTO>>(listUsers);

            return new GenericRespDTO<List<UserRespDTO>>("OK", "Transaction successfully processed", userListDTO);
        }

        public async Task<GenericRespDTO<string>> SaveCompany(GenericReqDTO<CompanyReqDTO> reqDTO)
        {
            _logger.LogInformation("Req SaveCompany() {}", reqDTO);

            await ValidUsernameExists(reqDTO.Payload.UserReqDTO.Username);

            var companyModel = _mapper.Map<Company>(reqDTO.Payload);
            var userModel = _mapper.Map<User>(reqDTO.Payload.UserReqDTO);

            userModel.Company = companyModel;
            userModel.Status = IntegrityApiConstants.StatusActive;
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
            userModel.CompanyId = RetrieveIdCompanySession();
            userModel.Password = AuthUtil.HashPassword(userModel.Password);
            userModel.Status = IntegrityApiConstants.StatusActive;
            userModel.CreateAt = DateTime.Now;

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

        private int RetrieveIdCompanySession()
        {

            var userLogin = RetriveClaimsPrincipal();

            var idCompany = JwtClaimsHelper.GetCompanyId(userLogin)
                ?? throw new BadCredentialException("A company was not found in session");

            return int.Parse(idCompany);
        }

        public async Task<GenericRespDTO<UserRespDTO>> FindUser(int id)
        {
            _logger.LogInformation("Id user find: {}", id);

            var userModel = await RetrieveUserById(id);

            var userResp = _mapper.Map<UserRespDTO>(userModel);

            return new GenericRespDTO<UserRespDTO>("OK", "User Found succcess", userResp);
        }

        public async Task<GenericRespDTO<string>> UpdateUser(GenericReqDTO<UpdateUserReqDTO> reqDTO, int id)
        {

            _logger.LogInformation("Updated user: {} id: {}", reqDTO, id);

            var userModel = await RetrieveUserById(id);


            var newDataUser = reqDTO.Payload;
            userModel.Email = newDataUser.Email;
            userModel.Names = newDataUser.Names;
            userModel.LasName = newDataUser.LasName;

            await _dBContextTest.SaveChangesAsync();

            return new GenericRespDTO<string>("OK", "User Updated succcess", userModel.Id.ToString());
        }

        public async Task<GenericRespDTO<string>> UpdatePasswordUser(GenericReqDTO<string> reqDTO, int id)
        {
            _logger.LogInformation("Req UpdatePasswordUser: {}, id:{}", reqDTO, id);

            var userModel =  await RetrieveUserById(id);
            userModel.Password = AuthUtil.HashPassword(reqDTO.Payload);

            await _dBContextTest.SaveChangesAsync();

            return new GenericRespDTO<string>("OK", "Password User updated succcess", "");
        }

        public async  Task<GenericRespDTO<string>> DeleteUser(int id)
        {

            var userModel = await RetrieveUserById(id);
            userModel.Status = IntegrityApiConstants.StatusDelete;
            await _dBContextTest.SaveChangesAsync();

            return new GenericRespDTO<string>("OK", "User deleted succcess", "");
        }

        private async Task<User> RetrieveUserById(int id) 
        {

            return await _dBContextTest
                                       .Users
                                       .Where(x => x.Id == id && x.Status.Equals(IntegrityApiConstants.StatusActive))
                                       .FirstOrDefaultAsync()
                                       ?? throw new NotFoundException($"User with id {id} no exist");
        }


    }
}
