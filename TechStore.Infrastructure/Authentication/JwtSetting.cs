namespace TechStore.Infrastructure.Authentication
{
    public record JwtSetting
    {
        public const string SectionName = "JwtSetting";
        public string? Secret { get; init; }
        public int ExpiryMinutes { get; init; }
        public string? Issuer { get; init; }
        public string? Audience { get; init; }
    }
}
