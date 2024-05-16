using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Domain.Entities;

namespace TechStore.Application.Services.Authentication
{
    public record AuthResult (
        User User,
        string Token
        );
}
