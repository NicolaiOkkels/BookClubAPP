using System.Collections.Generic;
using BookClubApp.DataAccess.Entities;

namespace BookClubApp.DataAccess.Repositories
{
    public interface ILibraryRepository
    {
        Task<Libraries> GetLibraryByIdAsync(int id);
        Task<IEnumerable<Libraries>> GetLibrariesAsync();
    }
}