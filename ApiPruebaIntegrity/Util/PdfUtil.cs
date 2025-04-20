using ApiPruebaIntegrity.Models;

namespace ApiPruebaIntegrity.Util
{
    public class PdfUtil
    {
        public static Dictionary<string, string> GenerateKeysInvoicePdf(Invoice invoice, Company company)
        {

            Dictionary<string, string> mapValues = new Dictionary<string, string>();
            mapValues.Add("[KEY_COMPANY_NAME]", company.FullName);
            mapValues.Add("[KEY_COMPANY_ADDRESS]", company.City);
            mapValues.Add("[KEY_INVOICE_NUMBER]", invoice.InvoiceNumber);
            mapValues.Add("[KEY_DATE_CREATE]", $"{invoice.CreateAt}");
            mapValues.Add("[KEY_FULLNAME_CUSTOMER]", invoice.FullNameCustomer);
            mapValues.Add("[KEY_TLF_CUSTOMER]", invoice.CellPhoneCustomer);
            mapValues.Add("[KEY_EMAIL_CUSTOMER]", invoice.EmailCustomer);
            mapValues.Add("[KEY_FULLNAME_USER]", invoice.FullNameUser.ToString());
            mapValues.Add("[KEY_PORCENTAJE_IVA]", invoice.PorcentajeIva.ToString());
            mapValues.Add("[KEY_VALOR_IVA]", invoice.IvaValue.ToString());
            mapValues.Add("[KEY_SUBTOTAL]", invoice.SubTotal.ToString());
            mapValues.Add("[KEY_DETAILS]", GenerarRowsDetailsInvoice(invoice.Details));
            mapValues.Add("[KEY_PAY_FORMS]", GenerarRowsPayFormsInvoice(invoice.InvoicePayForm));
            mapValues.Add("[KEY_TOTAL]", invoice.Total.ToString());


            return mapValues;
        }


        public static string GenerarRowsDetailsInvoice(List<InvoiceDetail> invoiceDetails)
        {
            string tablaHtml = "";
            int index = 1;
            foreach (var detail in invoiceDetails)
            {
                tablaHtml += $"""
                    <tr>
                        <td>{index}</td>
                        <td>{detail.Amount}</td>
                        <td >{detail.Description}</td>
                        <td class="text-right">{detail.Price}</td>
                        <td class="text-right">${detail.Subtotal:F2}</td>
                    </tr>
                    """;
                index++;
            }
            return tablaHtml;
        }

        public static string GenerarRowsPayFormsInvoice(List<InvoicePayForm> invoicePayForm)
        {
            string tablaHtml = "";
            foreach (var payForm in invoicePayForm)
            {
                tablaHtml += $"""
                    <tr>
                        <td>{payForm.Description}</td>
                        <td class="text-right">{payForm.Total}</td>
                    </tr>
                    """;
            }
            return tablaHtml;
        }
    }
}
