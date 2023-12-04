using System.Text;
using BookClubApp.Business.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        services.AddScoped<IAuthService, AuthService>();
    }

    public static void RegisterJWT(this IServiceCollection services)
    {
        // Configure JWT authentication
        var jwtSecretKey = Encoding.ASCII.GetBytes("E7x32Fm8Vd1D9kGY4TpJrY/+y4/RNywu/I78mY+p+28="); //TODO: put in a more secure place

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(jwtSecretKey),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true // Check token expiration
            };
        });
    }
}