using TechStore.Application.Common.Interfaces.Persistence;
using TechStore.Domain.Entities;

namespace TechStore.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User GetByEmail(string email)
        {
            return _users.FirstOrDefault(e => e.Email == email)!;
        }
    }
}
