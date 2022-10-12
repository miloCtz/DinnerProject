using Application.Persistence;
using Domain.Entities;

namespace Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly static List<User> users = new();

        public void Add(User user)
        {
            users.Add(user);
        }

        public User? GetByEmail(string email)
        {
            return users.SingleOrDefault(x => x.Email == email);
        }
    }
}
