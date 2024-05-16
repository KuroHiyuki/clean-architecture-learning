namespace TechStore.Presentation.Authentication
{
    public record LoginRequest(
        string Email,
        string Password);
}
