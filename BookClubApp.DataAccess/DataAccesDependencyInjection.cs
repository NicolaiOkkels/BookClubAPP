using BookClubApp.DataAccess.Data;
using BookClubApp.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookClubApp.DataAccess;
public static class DataAccesDependencyInjection
{
    public static void RegisterDataAccesDependencies(this IServiceCollection services/*, IConfiguration configuration*/)
    {
        services.AddScoped<IBookClubRepository, BookClubRepository>();
        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IRatingRepository, RatingRepository>();
        services.AddScoped<ILibraryRepository, LibraryRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<IMembershipRepository, MembershipRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IPollRepository, PollRepository>();
        services.AddScoped<IVoteRepository, VoteRepository>();
    }
}