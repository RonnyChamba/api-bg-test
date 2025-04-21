using ApiPruebaIntegrity.Data;
using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;
using ApiPruebaIntegrity.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaIntegrity.Services.Impl
{
    public class CompanyServiceImpl : ICompanyService
    {

        private readonly ILogger<CompanyServiceImpl> _logger;
        private readonly DBContextTest _dBContextTest;
        private readonly IMapper _mapper;
        private readonly ISessionService _sessionService;

        public CompanyServiceImpl(ILogger<CompanyServiceImpl> logger, DBContextTest dBContextTest, IMapper mapper, ISessionService sessionService)
        {
            _logger = logger;
            _dBContextTest = dBContextTest;
            _mapper = mapper;
            _sessionService = sessionService;
        }
        public async Task<GenericRespDTO<CompanyRespDTO>> RetrieveCompanyUserInSession()
        {

            var companyIdUser = _sessionService.RetrieveIdCompanySession();
            _logger.LogInformation("id company: {}", companyIdUser);

            var company = await _dBContextTest
                .Companies
                .Where(c => c.Id == companyIdUser)
                .FirstOrDefaultAsync()
                ?? throw  new NotFoundException($"Company id { companyIdUser} not exists");

            var companyDTOResp = _mapper.Map<CompanyRespDTO>(company);

            return new GenericRespDTO<CompanyRespDTO>("OK", "Company retrieve Ok", companyDTOResp);
        }

        public  async Task<GenericRespDTO<string>> UpdateCompanyInSession(GenericReqDTO<CompanySimpleReqDTO> reqDTO, int id)
        {
            _logger.LogInformation("Req UpdateCompanyInSession(): {}  ide: {}", reqDTO, id);

            var newDataReqDTO = reqDTO.Payload;

            var companyModel = await _dBContextTest
                .Companies
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync()
                 ?? throw new NotFoundException($"Company id {id} not exists");

            companyModel.FullName = newDataReqDTO.FullName;
            companyModel.PorcentajeIva = newDataReqDTO.PorcentajeIva;
            companyModel.City = newDataReqDTO.City;

            await _dBContextTest.SaveChangesAsync();

            return new GenericRespDTO<string>("OK","Company updated success", "");
        }
    }
}
