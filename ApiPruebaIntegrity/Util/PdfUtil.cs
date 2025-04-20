using ApiPruebaIntegrity.Models;

namespace ApiPruebaIntegrity.Util
{
    public class PdfUtil
    {
        public static Dictionary<string, string> GenerateKeysInvoicePdf(Invoice invoice)
        {

            Dictionary<string, string> mapValues = new Dictionary<string, string>();
            //mapValues.Add("[KEY_COMPANY_NAME]", ConstantVeagro.COMPANY_NAME);
            //mapValues.Add("[KEY_COMPANY_ADDRESS]", ConstantVeagro.COMPANY_ADDRESS);
            //mapValues.Add("[KEY_COMPANY_TLF]", "092325634O");
            //mapValues.Add("[KEY_INVOICE_NUMBER]", $"{sale.Id}");
            //mapValues.Add("[KEY_DATE_CREATE]", $"{sale.CreateDate}");
            //mapValues.Add("[KEY_FULLNAME_CUSTOMER]", sale.Name);
            //mapValues.Add("[KEY_TLF_CUSTOMER]", sale.Cellphone ?? "NA");
            //mapValues.Add("[KEY_EMAIL_CUSTOMER]", sale.Email ?? "NA");
            //mapValues.Add("[KEY_ADDRESS_CUSTOMER]", sale.Address ?? "NA");
            //mapValues.Add("[KEY_ROWS_DETAILS]", TemplateUtil.GenerarRowsDetailsSale(sale.Details));
            //mapValues.Add("[KEY_TOTAL_SALE]", sale.Total.ToString());


            return mapValues;
        }
    }
}
