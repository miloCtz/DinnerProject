using Domain.Entities;

namespace Application.Auth
{
    public record AuthResult(
        User User,
        string Token);
}