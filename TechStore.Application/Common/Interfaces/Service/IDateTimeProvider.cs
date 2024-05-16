namespace TechStore.Application.Common.Interfaces.DateProvider
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
