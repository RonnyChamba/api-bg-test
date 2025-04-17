namespace ApiPruebaIntegrity.Util
{
    public class AuthUtil
    {

        public static string HashPassword(string plainTextPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainTextPassword);
        }
        public static bool VerifyPassword(string plainTextPassword, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(plainTextPassword, passwordHash);
        }

    }
}
