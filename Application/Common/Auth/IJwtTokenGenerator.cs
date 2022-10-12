using Domain.Entities;

namespace Application.Common.Auth
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
