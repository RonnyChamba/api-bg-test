namespace ApiPruebaIntegrity.Security.DTOs
{
    public record JwtSettingsDTO
    (
        string Key,
        string Issuer,
        string Audience,
        int ExpireMinutes
    );
}
