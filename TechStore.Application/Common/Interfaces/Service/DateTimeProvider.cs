using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Application.Common.Interfaces.DateProvider;

namespace TechStore.Application.Common.Interfaces.Service
{
    internal class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
