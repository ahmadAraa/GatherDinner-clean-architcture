using GatherDinner.Application.Common.Interfaces.Presistence;
using GatherDinner.Domain.Entities;

namespace GatherDinner.Infrastructure.Presistance
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(x=> x.Email == email);
        }

    }
}