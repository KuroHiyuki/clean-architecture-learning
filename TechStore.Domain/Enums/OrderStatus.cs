using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.Domain.Enums
{
    public enum OrderStatus
    {
        OrderProcessing = 0,
        OrderShipped =1,
        InTransit = 2,
        Delivered = 3
    }
}
