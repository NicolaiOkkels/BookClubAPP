using BookClubApp.DataAccess.Entities;

namespace BookClubApp.Business.Services
{
    public interface ILibraryService
    {
        Task<IEnumerable<Libraries>> GetLibrariesAsync();
        Task<Libraries> GetLibraryByIdAsync(int id);
    }
}