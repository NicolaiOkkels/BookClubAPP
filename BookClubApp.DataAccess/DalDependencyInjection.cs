using BookClubApp.DataAccess.Data;
using BookClubApp.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookClubApp.DataAccess;
public static class DataAccesDependencyInjection
{
    public static void RegisterDataAccesDependencies(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(Configuration.GetConnectionString("TestConnection"));
        });

        services.AddScoped<IBookClubRepository, BookClubRepository>();
        services.AddScoped<IMemberRepository, MemberRepository>();
    }

}