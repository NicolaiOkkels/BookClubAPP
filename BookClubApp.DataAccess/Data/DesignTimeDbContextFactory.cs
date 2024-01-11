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
            optionsBuilder.UseSqlServer("Server=tcp:bookclub-sql-server.database.windows.net,1433;Initial Catalog=bookclub-sql-db;Persist Security Info=False;User ID=CloudSA941f200c;Password=hp%uSqOOT4G(=lZ;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}