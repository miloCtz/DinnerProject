using ErrorOr;
using MediatR;

namespace Application.Auth.Queries.Login
{
    public record class LoginQuery(
        string Email,
        string Password) : IRequest<ErrorOr<AuthResult>>;
}
