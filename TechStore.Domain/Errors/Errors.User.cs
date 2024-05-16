using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Domain.Entities;

namespace TechStore.Domain.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error EmailExists => Error.Conflict(
                code: "User.EmailExists.",
                description: "Email is already in use.");
        }
    }
}
