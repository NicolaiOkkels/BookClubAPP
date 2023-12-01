using BookClubApp.Business.Services;

namespace BookClubApp.Business;

public static class BusinessLayerDependencyInjection
{
    public static void RegisterBusinessLayerDependencies(this IServiceCollection services)
    {
        services.AddScoped<BookClubService>();
        services.AddScoped<MemberService>();
        services.AddScoped<RatingService>();
        services.AddScoped<SearchService>();
    }
}