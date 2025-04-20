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
    public class InvoiceServiceImpl : IInvoiceService
    {

        private readonly ILogger<InvoiceServiceImpl> _logger;
        private readonly DBContextTest _dBContextTest;
        private readonly IMapper _mapper;

        public InvoiceServiceImpl(ILogger<InvoiceServiceImpl> logger, DBContextTest dBContextTest, IMapper mapper)
        { 
            _logger = logger;
            _dBContextTest = dBContextTest;
            _mapper = mapper;
        
        }
        public async Task<GenericRespDTO<string>> CreateInvoice(GenericReqDTO<InvoiceReqDTO> reqDTO)
        {

            _logger.LogInformation("Req CreateInvoice: {}", reqDTO);

            var invoice = new Invoice();

            var dataReqInvoice = reqDTO.Payload;
            SetInfoGeneralInvoice(dataReqInvoice, invoice);
            await SetInfoCustomerInvoice(dataReqInvoice, invoice);
            await SetInfoUserInvoice(dataReqInvoice, invoice);
            invoice.Details = _mapper.Map<List<InvoiceDetail>>(dataReqInvoice.Details);
            invoice.InvoicePayForm = _mapper.Map<List<InvoicePayForm>>(dataReqInvoice.InvoicePayForm);


            await _dBContextTest.Invoices.AddAsync(invoice);
            await _dBContextTest.SaveChangesAsync();

            return new GenericRespDTO<string>("OK", "Invoice generate success", "");
        }

        private void SetInfoGeneralInvoice(InvoiceReqDTO invoiceReqDTO, Invoice invoice) {

            invoice.InvoiceNumber = "124344363435";
            invoice.PorcentajeIva = invoiceReqDTO.PorcentajeIva;
            invoice.IvaValue = invoiceReqDTO.IvaValue;
            invoice.StatusPay = invoiceReqDTO.StatusPay;
            invoice.Status = IntegrityApiConstants.StatusActive;
            invoice.SubTotal = invoiceReqDTO.SubTotal;
            invoice.Total = invoiceReqDTO.Total;
        }

        private async Task SetInfoCustomerInvoice(InvoiceReqDTO invoiceReqDTO, Invoice invoice) { 
        
            var customerId = invoiceReqDTO.CustomerId;

            var customerModel = await _dBContextTest
                .Customers
                .Where(x => x.Id == customerId && x.Status.Equals(IntegrityApiConstants.StatusActive))
                .FirstOrDefaultAsync()
                ?? throw new NotFoundException($"Customer with id {customerId} not exists");

            invoice.CellPhoneCustomer = customerModel.CellPhone;
            invoice.CustomerId = customerModel.Id;
            invoice.EmailCustomer = customerModel.Email;
            invoice.FullNameCustomer = customerModel.FullName;   
        }

        private async Task SetInfoUserInvoice(InvoiceReqDTO invoiceReqDTO, Invoice invoice) {

            var userId = invoiceReqDTO.UserId;

           
            var userModel = await _dBContextTest
                .Users
                .Where(x => x.Id == userId && x.Status.Equals(IntegrityApiConstants.StatusActive))
                .FirstOrDefaultAsync()
                ?? throw new NotFoundException($"User with id {userId} not exists");

            invoice.UserId = userId;
            invoice.FullNameUser = $"{userModel.Names} {userModel.LasName}";
        }

    }
}
