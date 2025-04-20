using ApiPruebaIntegrity.Exceptions;
using System.Globalization;

namespace ApiPruebaIntegrity.Util
{
    public class DateUtil
    {
        public static DateTime GetDateTimeFromString(string date) 
        {

            if (DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha))
            {
                return fecha.Date + DateTime.Now.TimeOfDay;
            }
            else
            {
                throw new GenericException("The invoice date is not in a valid format (dd/MM/yyyy).");
            }

        }
    }
}
