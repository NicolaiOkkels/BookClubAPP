using BookClubApp.DataAccess.Data;
using BookClubApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookClubApp.DataAccess.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly ApplicationDbContext _context;

        public LibraryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Libraries>> GetLibrariesAsync()
        {
            return await _context.Libraries.ToListAsync();
        }

        public async Task<Libraries> GetLibraryByIdAsync(int id)
        {
            return await _context.Libraries.FindAsync(id);
        }
        

    }
}