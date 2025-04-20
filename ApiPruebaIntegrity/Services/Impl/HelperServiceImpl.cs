using ApiPruebaIntegrity.Data;
using ApiPruebaIntegrity.DTOs.Response;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaIntegrity.Services.Impl
{
    public class HelperServiceImpl : IHelperService
    {

        private readonly DBContextTest _dBContextTest;
        private readonly ILogger<HelperServiceImpl> _logger;
        private readonly IMapper _mapper;

        public HelperServiceImpl(DBContextTest dBContextTest, ILogger<HelperServiceImpl> logger, IMapper mapper) 
        {
            _dBContextTest = dBContextTest;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<GenericRespDTO<List<PayFormRespDTO>>> FindAllPayForm()
        {
            _logger.LogInformation("Getting formas");
            
            var payFormsModel = await _dBContextTest
                .PayForms
                .ToListAsync();

            var listResDTO = _mapper.Map<List<PayFormRespDTO>>(payFormsModel);

            return new GenericRespDTO<List<PayFormRespDTO>>("OK", "Transaction successfully processed", listResDTO);
        }
    }
}
