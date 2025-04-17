namespace ApiPruebaIntegrity.Security.DTOs
{
    public record JwtSettingDTO
    (
        string Key,
        string Issuer,
        string Audience,
        int ExpireMinutes
    );
}
