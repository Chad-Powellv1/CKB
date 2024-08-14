using CKB.Application.Authentication.Common;
using CKB.Contracts.Authentication;
using CKB.Domain.Users.ValueObjects;
using Mapster;

namespace CKB.Api.Common.Mapping;
  
public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User)
            .Map(dest => dest.Id, src => UserId.Create(src.User.Id.Value));
    }
}