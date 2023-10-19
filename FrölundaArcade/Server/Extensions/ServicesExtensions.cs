using FrölundaArcade.Server.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using System.Security.Claims;

namespace FrölundaArcade.Server.Extensions;

public static class ServicesExtensions
{
    public static void AddAuth(this IServiceCollection services)
    {
        services.AddDefaultIdentity<AppUser>(options => options.Password.RequireNonAlphanumeric = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>();

        services.AddIdentityServer()
            .AddApiAuthorization<AppUser, AppDbContext>()
            .AddProfileService<ProfileService>();

        services.AddAuthorization(opt =>
        {
            opt.AddPolicy(Constants.Admin, p => p.RequireClaim(ClaimTypes.Role, Constants.Admin));
        });

        services.AddAuthentication().AddIdentityServerJwt();
    }

    public static async Task AddDbAsync(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
    {
        var connectionString = isDevelopment ? configuration.GetConnectionString("Development") : await GetProductionConnectionString(configuration);
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
        services.AddDatabaseDeveloperPageExceptionFilter();
    }

    private static async Task<string> GetProductionConnectionString(IConfiguration configuration)
    {
        var secretUri = configuration.GetConnectionString("Production");
        var keyVaultToken = new AzureServiceTokenProvider().KeyVaultTokenCallback;
        var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(keyVaultToken));
        return (await keyVaultClient.GetSecretAsync(secretUri)).Value;
    }
}