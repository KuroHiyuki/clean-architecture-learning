using TechStore.Application.Common.Interfaces.DateProvider;

namespace TechStore.Application.Common.Interfaces.Service
{
    internal class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
