using Application.Auth;
using Contracts.Auth;
using Mapster;

namespace WebApi.Mappings
{
    public class AuthMapConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthResult, AuthResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest, src => src.User);
        }
    }
}
