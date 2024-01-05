using BookClubApp.DataAccess.Entities;
using BookClubApp.DataAccess.Repositories;

namespace BookClubApp.Business.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _libraryRepository;
    
        public LibraryService(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        public async Task<Libraries> GetLibraryByIdAsync(int id)
        {
            var returnedLibrary = await _libraryRepository.GetLibraryByIdAsync(id);
            return returnedLibrary;
        }

        public async Task<IEnumerable<Libraries>> GetLibrariesAsync()
        {
            return await _libraryRepository.GetLibrariesAsync();
        }

    }
}