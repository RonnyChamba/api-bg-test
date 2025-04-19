using ApiPruebaIntegrity.Data;
using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;
using ApiPruebaIntegrity.Models;
using ApiPruebaIntegrity.Util;
using AutoMapper;

namespace ApiPruebaIntegrity.Services.Impl
{
    public class ProductServiceImpl : IProductService
    {
        private readonly ILogger<ProductServiceImpl> _logger;
        private readonly IMapper _mapper;
        private readonly DBContextTest _dBContextTest;
        private readonly ISessionService _sessionService;

        public ProductServiceImpl(ILogger<ProductServiceImpl> logger, IMapper mapper, DBContextTest dBContextTest, ISessionService sessionService)
        { 
            _logger = logger;
            _mapper = mapper;
            _dBContextTest = dBContextTest;
            _sessionService = sessionService;
        }
        public async Task<GenericRespDTO<string>> SaveProduct(GenericReqDTO<ProductReqDTO> reqDTO)
        {
            _logger.LogInformation("Req SaveProduct: {}", reqDTO);

            var modelProduct = _mapper.Map<Product>(reqDTO.Payload);
            modelProduct.Status = IntegrityApiConstants.StatusActive;
            modelProduct.CompanyId = _sessionService.RetrieveIdCompanySession();

            await _dBContextTest.Products.AddAsync(modelProduct);
            await _dBContextTest.SaveChangesAsync();


            return new GenericRespDTO<string>("OK", "Product successfully created", "");
        }
    }
}
