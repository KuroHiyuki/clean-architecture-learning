using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Application.Services.Authentication;

namespace TechStore.Application.Authentication.Login.Queries
{
    public record LoginQuery(
        string Email,
        string Password):IRequest<ErrorOr<AuthResult>>;
}
