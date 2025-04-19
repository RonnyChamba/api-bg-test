using ApiPruebaIntegrity.Data;
using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;

namespace ApiPruebaIntegrity.Services.Impl
{
    public class InvoiceServiceImpl : IInvoiceService
    {

        private readonly ILogger<InvoiceServiceImpl> _logger;
        private readonly DBContextTest _dBContextTest;

        public InvoiceServiceImpl(ILogger<InvoiceServiceImpl> logger, DBContextTest dBContextTest)
        { 
            _logger = logger;
            _dBContextTest = dBContextTest;
        
        }
        public async Task<GenericRespDTO<string>> CreateInvoice(GenericReqDTO<InvoiceReqDTO> reqDTO)
        {

            _logger.LogInformation("Req CreateInvoice: {}", reqDTO);



            var resp = reqDTO.Payload.InvoicePayForm;
            return new GenericRespDTO<string>("", "", "");
        }
    }
}
