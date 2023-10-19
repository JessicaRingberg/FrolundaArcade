using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;

namespace FrölundaArcade.Server.Data;
public class ProfileService : IProfileService
{
    public Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var roles = context.Subject.FindAll(JwtClaimTypes.Role);
        var email = context.Subject.FindFirst(JwtClaimTypes.Email);

        context.IssuedClaims.AddRange(roles);
        context.IssuedClaims.Add(email);

        return Task.CompletedTask;
    }

    public Task IsActiveAsync(IsActiveContext context)
    {
        return Task.CompletedTask;
    }
}
