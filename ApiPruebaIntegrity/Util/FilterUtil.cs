using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.Enums;
using ApiPruebaIntegrity.Models;

namespace ApiPruebaIntegrity.Util
{
    public class FilterUtil
    {

        public static GenericReqDTO<FilterInvoiceReqDTO> GenericReqFilterInvoice(string? valueFilter,
                                                                                 InvoiceFilterTypeEnum? invoiceFilterType,
                                                                                 ComparisonOperatorEnum? comparisonOperator) 
        {
            var filterReqDTO = new FilterInvoiceReqDTO(valueFilter, invoiceFilterType, comparisonOperator);
         
            return new GenericReqDTO<FilterInvoiceReqDTO>("API",filterReqDTO);
        }

        public static IQueryable<Invoice> ApplyFilter(IQueryable<Invoice> query, FilterInvoiceReqDTO filter)
        {
            if (string.IsNullOrWhiteSpace(filter.ValueFilter) || !filter.InvoiceFilterType.HasValue)
                return query;

            var value = filter.ValueFilter.ToUpper();

            switch (filter.InvoiceFilterType.Value)
            {
                case InvoiceFilterTypeEnum.CustomerName:
                    return query.Where(i => i.FullNameCustomer.ToUpper().Contains(value));

                case InvoiceFilterTypeEnum.InvoiceNumber:
                    return query.Where(i => i.InvoiceNumber.ToUpper().Contains(value));

                case InvoiceFilterTypeEnum.RangeDate:
                    return ApplyRangeDateFilter( query, value);

                case InvoiceFilterTypeEnum.InvoiceTotal:
                    return ApplyTotalFilter(query, value, filter.ComparisonOperator);
            }

            return query;
        }

        public static IQueryable<Invoice> ApplyRangeDateFilter(IQueryable<Invoice> query, string value)
        {

            if (string.IsNullOrWhiteSpace(value))
                return query;

            var dates = value.Split('|');

            if (dates.Length != 2)
                return query;

            if (!DateTime.TryParseExact(dates[0], "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out var startDate) ||
                !DateTime.TryParseExact(dates[1], "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out var endDate))
            {
                return query;
            }

            // Asegurarse de comparar solo la parte de la fecha
            startDate = startDate.Date;
            endDate = endDate.Date;

            return query.Where(invoice => invoice.CreateAt.Date >= startDate && invoice.CreateAt.Date <= endDate);

        }

        public static IQueryable<Invoice> ApplyTotalFilter(IQueryable<Invoice> query, string value, ComparisonOperatorEnum? op)
        {
            if (!decimal.TryParse(value, out var total) || !op.HasValue)
                return query;

            return op.Value switch
            {
                ComparisonOperatorEnum.LessThan => query.Where(i => i.Total < total),
                ComparisonOperatorEnum.LessThanOrEqual => query.Where(i => i.Total <= total),
                ComparisonOperatorEnum.EqualTo => query.Where(i => i.Total == total),
                ComparisonOperatorEnum.GreaterThan => query.Where(i => i.Total > total),
                ComparisonOperatorEnum.GreaterThanOrEqual => query.Where(i => i.Total >= total),
                _ => query
            };
        }
    }
}
