using Domain.Entities;

namespace Application.Persistence
{
    public interface IUserRepository
    {
        User? GetByEmail(string email);

        void Add(User user);
    }
}
