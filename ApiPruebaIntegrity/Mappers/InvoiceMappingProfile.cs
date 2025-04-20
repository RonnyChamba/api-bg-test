using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;
using ApiPruebaIntegrity.Models;
using AutoMapper;

namespace ApiPruebaIntegrity.Mappers
{
    public class InvoiceMappingProfile : Profile
    {
        public InvoiceMappingProfile() {

            CreateMap<InvoiceDetailReqDTO, InvoiceDetail>();
            CreateMap<InvoicePayFormReqDTO, InvoicePayForm>();
            CreateMap<Invoice, InvoiceRespDTO>();
            CreateMap<Invoice, RetrieveFullInvoiceRespDTO>();
            CreateMap<InvoiceDetail, InvoiceDetailRespDTO>();
            CreateMap<InvoicePayForm, InvoicePayFormRespDTO>();
        }
    }
}
