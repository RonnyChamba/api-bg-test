namespace ApiPruebaIntegrity.Exceptions
{
    public class ConflictException: GenericException
    {

        public ConflictException(string message) : base(message, StatusCodes.Status409Conflict)
        {
        }

        public ConflictException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
