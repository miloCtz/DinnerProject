using Application.Common.Auth;
using Application.Common.Errors;
using Application.Persistence;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Auth.Queries.Login
{
    public class LoginQueryHandler :
        IRequestHandler<LoginQuery, ErrorOr<AuthResult>>
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IUserRepository userRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            User? user = userRepository.GetByEmail(request.Email);

            if (user is null || !string.Equals(user.Password, request.Password))
            {
                return Errors.Auth.InvalidCredentials;
            }

            string token = jwtTokenGenerator.GenerateToken(user);

            return new AuthResult(user, token);
        }
    }
}
