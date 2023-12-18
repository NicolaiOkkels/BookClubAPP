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

    public static void AntiForgeryConfiguration(this IServiceCollection services)
    {
        services.AddAntiforgery(options =>
        {
            options.HeaderName = "X-XSRF-TOKEN";
            options.SuppressXFrameOptionsHeader = false;

            // Set the properties of the CSRF cookie
            options.Cookie.HttpOnly = false; // Allows JavaScript access to the cookie. Keep this as is for CSRF protection.

            // For local development, SecurePolicy is set to SameAsRequest, which means the cookie's security will match the request's security (HTTP or HTTPS).
            // For production, change this to CookieSecurePolicy.Always to enforce sending the cookie only over HTTPS.
            options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;

            // SameSite is set to None to allow the cookie to be sent in cross-origin requests, which is common in local development.
            // This setting is also valid for production, especially if your API and frontend are on different domains.
            // However, ensure that you use HTTPS in production when SameSite is None, and set SecurePolicy to Always.
            options.Cookie.SameSite = SameSiteMode.None;
        });
    }
}