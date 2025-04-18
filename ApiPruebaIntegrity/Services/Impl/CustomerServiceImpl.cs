using ApiPruebaIntegrity.Data;
using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;
using ApiPruebaIntegrity.Models;
using ApiPruebaIntegrity.Util;
using AutoMapper;

namespace ApiPruebaIntegrity.Services.Impl
{
    public class CustomerServiceImpl : ICustomerService
    {

        private readonly ILogger<CustomerServiceImpl> _logger;
        private readonly DBContextTest _dBContextTest;
        private readonly IMapper _mapper;
        private readonly ISessionService _sessionService;

        public CustomerServiceImpl(ILogger<CustomerServiceImpl> logger, DBContextTest dBContextTest, IMapper mapper, ISessionService sessionService) 
        {
            _logger = logger;
            _dBContextTest = dBContextTest;
            _mapper = mapper;
            _sessionService = sessionService;
        }
        public async Task<GenericRespDTO<string>> SaveCustomer(GenericReqDTO<CustomerReqDTO> reqDTO)
        {
            _logger.LogInformation("Req SaveCustomer: {}", reqDTO);

            var customerModel = _mapper.Map<Customer>(reqDTO.Payload);
            customerModel.Status = IntegrityApiConstants.StatusActive;
            customerModel.CompanyId = _sessionService.RetrieveIdCompanySession();

            await _dBContextTest.Customers.AddAsync(customerModel);
            await _dBContextTest.SaveChangesAsync();

            return new  GenericRespDTO<string>("OK", "User created success", ""); 
        }
    }
}
