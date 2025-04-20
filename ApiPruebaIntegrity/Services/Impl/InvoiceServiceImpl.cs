using ApiPruebaIntegrity.Data;
using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;
using ApiPruebaIntegrity.Enums;
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
        private readonly ISessionService _sessionService;

        public InvoiceServiceImpl(ILogger<InvoiceServiceImpl> logger, DBContextTest dBContextTest, IMapper mapper, ISessionService sessionService)
        {
            _logger = logger;
            _dBContextTest = dBContextTest;
            _mapper = mapper;
            _sessionService = sessionService;

        }
        public async Task<GenericRespDTO<string>> CreateInvoice(GenericReqDTO<InvoiceReqDTO> reqDTO)
        {

            _logger.LogInformation("Req CreateInvoice: {}", reqDTO);

            var invoice = new Invoice();

            var dataReqInvoice = reqDTO.Payload;
            await SetInfoGeneralInvoice(dataReqInvoice, invoice);
            await SetInfoCustomerInvoice(dataReqInvoice, invoice);
            await SetInfoUserInvoice(dataReqInvoice, invoice);
            invoice.Details = _mapper.Map<List<InvoiceDetail>>(dataReqInvoice.Details);
            invoice.InvoicePayForm = _mapper.Map<List<InvoicePayForm>>(dataReqInvoice.InvoicePayForm);


            await _dBContextTest.Invoices.AddAsync(invoice);
            await _dBContextTest.SaveChangesAsync();

            return new GenericRespDTO<string>("OK", "Invoice generate success", "");
        }

        private async Task SetInfoGeneralInvoice(InvoiceReqDTO invoiceReqDTO, Invoice invoice) {

            invoice.InvoiceNumber = await GenerateSequentialInvoice();
            invoice.CreateAt = DateUtil.GetDateTimeFromString(invoiceReqDTO.CreateAt);
            invoice.PorcentajeIva = invoiceReqDTO.PorcentajeIva;
            invoice.IvaValue = invoiceReqDTO.IvaValue;
            invoice.StatusPay = invoiceReqDTO.StatusPay;
            invoice.Status = IntegrityApiConstants.StatusActive;
            invoice.SubTotal = invoiceReqDTO.SubTotal;
            invoice.Total = invoiceReqDTO.Total;
            invoice.CompanyId = _sessionService.RetrieveIdCompanySession();
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

        private async Task<string> GenerateSequentialInvoice() {


            var sequence = await _dBContextTest
                .InvoiceSequences
                .FindAsync(1) ?? throw new NotFoundException("No sequence configured for invoices.");

            _logger.LogInformation("Current sequence: {}", sequence.LastNumber);

            sequence.LastNumber++;

            await _dBContextTest.SaveChangesAsync();

            return sequence.LastNumber.ToString("D10");
        }

        public async Task<GenericRespDTO<List<InvoiceRespDTO>>> FindAllInvoice(GenericReqDTO<FilterInvoiceReqDTO> reqDTO)
        {
            _logger.LogInformation("Req FindAllInvoice: {}", reqDTO);

            var companyId = _sessionService.RetrieveIdCompanySession();

            var query = _dBContextTest
                .Invoices
                .Where(x => x.CompanyId == companyId &&
                            x.Status.Equals(IntegrityApiConstants.StatusActive));

            query = FilterUtil.ApplyFilter(query, reqDTO.Payload);

            var invoicesModel = await query.ToListAsync();
            var invoicesResp = _mapper.Map<List<InvoiceRespDTO>>(invoicesModel);

            return new GenericRespDTO<List<InvoiceRespDTO>> ("OK", "Operation Success", invoicesResp);
        }
    }
}
