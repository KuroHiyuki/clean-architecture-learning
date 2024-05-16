using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Application.Services.Authentication;

namespace TechStore.Application.Authentication.Register.Commands
{
    public record RegisterCommand(
        string FirstName, 
        string LastName, 
        string Email, 
        string Password):IRequest<ErrorOr<AuthResult>>;
}
