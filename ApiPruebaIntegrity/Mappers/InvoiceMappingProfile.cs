using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.Models;
using AutoMapper;

namespace ApiPruebaIntegrity.Mappers
{
    public class InvoiceMappingProfile : Profile
    {
        public InvoiceMappingProfile() {

            CreateMap<InvoiceDetailReqDTO, InvoiceDetail>();
            CreateMap<InvoicePayFormReqDTO, InvoicePayForm>();
        }
    }
}
