using TechStore.Application.Common.Interfaces.DateProvider;

namespace TechStore.Infrastructure.Service
{
    internal class DateTimProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
