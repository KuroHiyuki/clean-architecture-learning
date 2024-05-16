
using TechStore.Domain.Entities;

namespace TechStore.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User GetByEmail(string email);
        void Add(User user);

    }
}
