using System.Security.Claims;
using System.Text;
using BookClubApp.Business.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;

namespace BookClubApp.Business;

public static class BusinessLayerDependencyInjection
{
    
    public static void RegisterBusinessLayerDependencies(this IServiceCollection services)
    {
        services.AddScoped<IBookClubService, BookClubService>();
        services.AddScoped<IMemberService, MemberService>();
        services.AddScoped<IRatingService, RatingService>();
        services.AddScoped<ISearchService, SearchService>();
        services.AddScoped<ILibraryService, LibraryService>();
        services.AddScoped<IMessageService, MessageService>();
    }

    public static void RegisterJWT(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.Authority = $"https://{configuration["Auth0:Domain"]}";
            options.Audience = configuration["Auth0:Audience"];
        });
    }
}