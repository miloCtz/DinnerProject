using Application.Auth.Commands.Register;
using Application.Auth.Queries.Login;
using Application.Common.Errors;
using Contracts.Auth;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("auth")]
    public class AuthController : ApiController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public AuthController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = this.mapper.Map<RegisterCommand>(request);

            var result = await mediator.Send(command);

            return result.MatchFirst(
                    authResult => Ok(this.mapper.Map<AuthResponse>(authResult)),
                    error => Problem(result.Errors));

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = this.mapper.Map<LoginQuery>(request);
            var result = await this.mediator.Send(query);

            if (result.IsError && result.FirstError == Errors.Auth.InvalidCredentials)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: result.FirstError.Description);
            }

            return result.MatchFirst(
                   authResult => Ok(this.mapper.Map<AuthResponse>(authResult)),
                   error => Problem(result.Errors));
        }
    }
}
