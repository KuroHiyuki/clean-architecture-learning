using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.Application.Common.Interfaces.DateProvider
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
