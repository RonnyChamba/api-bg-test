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

        public async Task<GenericRespDTO<List<ProductRespDTO>>> FindAllProducts(string paramFilter)
        {

            _logger.LogInformation("Req FindAllProducts : {}", paramFilter);

            int companyId = _sessionService.RetrieveIdCompanySession();

            var query = _dBContextTest
                .Products
                .Where(p => p.CompanyId == companyId && 
                       p.Status.Equals(IntegrityApiConstants.StatusActive));

            if (!string.IsNullOrWhiteSpace(paramFilter)) 
            {
                query = query.Where(p => p.Code.ToUpper().Contains(paramFilter) 
                                 || p.Description.ToUpper().Contains(paramFilter));
            }

            var productList = await query.ToListAsync();

            var listDTOs = _mapper.Map<List<ProductRespDTO>>(productList);

            return new GenericRespDTO<List<ProductRespDTO>> ("OK","Operation Success", listDTOs);
            
        }

        public async Task<GenericRespDTO<ProductRespDTO>> FindProductById(int id)
        {
            _logger.LogInformation("Found Product: {}", id);

            var productModel =  await RetrieveProducById(id)
                ?? throw new NotFoundException($"Product with id {id} not exists");

            var productRespDTO = _mapper.Map<ProductRespDTO>(productModel);

            return new GenericRespDTO<ProductRespDTO>("OK", "Operation Success", productRespDTO);
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

        public async Task<GenericRespDTO<string>> UpdateProduct(GenericReqDTO<UpdateProductReqDTO> reqDTO, int id)
        {
            _logger.LogInformation("Req UpdateProduct: {} id: {}", reqDTO, id);

            var productModel = await RetrieveProducById(id)
                               ?? throw new NotFoundException($"Product with id {id} not exists");

            var newDataReq = reqDTO.Payload;

            productModel.Code = newDataReq.Code;
            productModel.Description = newDataReq.Description;
            productModel.Price = newDataReq.Price;

            await _dBContextTest.SaveChangesAsync();
            return new GenericRespDTO<string>("OK", "Product successfully updated", productModel.Id.ToString());

        }

        private async Task<Product?> RetrieveProducById(int id)
        { 

            return await _dBContextTest
                .Products
                .Where(p => p.Status.Equals(IntegrityApiConstants.StatusActive)
                      &&    p.Id == id)
                .FirstOrDefaultAsync();
        
        }
    }
}
