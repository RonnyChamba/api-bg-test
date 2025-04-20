using ApiPruebaIntegrity.Data;
using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;
using ApiPruebaIntegrity.Exceptions;
using ApiPruebaIntegrity.Models;
using ApiPruebaIntegrity.Util;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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

        public async Task<GenericRespDTO<List<CustomerRespDTO>>> FindAllCustomers(string name)
        {
            _logger.LogInformation("Name {}", name);

            var idCompany = _sessionService.RetrieveIdCompanySession();

            var query = _dBContextTest
                .Customers
                .Where(c => c.CompanyId == idCompany && c.Status.Equals(IntegrityApiConstants.StatusActive));

            if (!string.IsNullOrWhiteSpace(name)) 
            {
                query = query.Where(user => user.FullName.Contains(name));

            }

            var listCustomers = await query.ToListAsync();
            var listRespDTO =_mapper.Map<List<CustomerRespDTO>>(listCustomers);

            return new GenericRespDTO<List<CustomerRespDTO>>("OK", "Transaction successfully processed", listRespDTO);


        }

        public async Task<GenericRespDTO<CustomerRespDTO>> FindCustomer(int id)
        {

            _logger.LogInformation("Id customer: {}", id);

            var customerModel = await RetrieveCustomer(id) 
                ?? throw new NotFoundException($"Customer with id {id} not exists");

            var customerResp = _mapper.Map<CustomerRespDTO>(customerModel);

            return new GenericRespDTO<CustomerRespDTO>("OK", "Customer found success", customerResp);
        }

        public async Task<GenericRespDTO<string>> UpdateCustomer(GenericReqDTO<UpdateCustomerReqDTO> reqDTO, int id)
        {
            _logger.LogInformation("UpdateCustomer: {} id: {}", reqDTO, id);

            var customerModel = await RetrieveCustomer(id)
                 ?? throw new NotFoundException($"Customer with id {id} not exists");

            var newData = reqDTO.Payload;

            customerModel.FullName = newData.FullName;
            customerModel.CellPhone = newData.CellPhone;
            customerModel.Address = newData.Address;
            customerModel.CellPhone = newData.CellPhone;
            customerModel.Email = newData.Email;

            await _dBContextTest.SaveChangesAsync();

            return new GenericRespDTO<string>("OK", "Customer updated success", customerModel.Id.ToString());

        }

        public async Task<GenericRespDTO<string>> DeleteCustomer(int id)
        {
            _logger.LogInformation("Id customer delete: {}", id);

            var customerModel = await RetrieveCustomer(id)
                   ?? throw new NotFoundException($"Customer with id {id} not exists");
            customerModel.Status = IntegrityApiConstants.StatusDelete;

            await _dBContextTest.SaveChangesAsync();

            return new GenericRespDTO<string>("OK", "Customer deleted success", customerModel.Id.ToString());

        }

        private async Task<Customer?> RetrieveCustomer(int id)
        {
            return await _dBContextTest
                .Customers
                .Where(c => c.Id == id && c.Status.Equals(IntegrityApiConstants.StatusActive))
                .FirstOrDefaultAsync();
        
        }
    }
}
