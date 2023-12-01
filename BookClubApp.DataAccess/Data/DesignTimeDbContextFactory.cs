using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BookClubApp.DataAccess.Data
{
    //used for migrations
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=BookClubDB;User Id=sa;Password=QrGIQg3:QJ;TrustServerCertificate=true;");
    
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}