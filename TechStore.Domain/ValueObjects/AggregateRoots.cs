using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.Domain.ValueObjects
{
    public abstract class AggregateRoots<TId>:BaseEntity<TId>
        where TId : notnull
    {
        protected AggregateRoots(TId id) : base(id) 
        { 

        }
    }
}
