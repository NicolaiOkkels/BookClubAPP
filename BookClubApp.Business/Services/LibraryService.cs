using BookClubApp.DataAccess.Entities;
using BookClubApp.DataAccess.Repositories;

namespace BookClubApp.Business.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _libraryRepository;
        //private readonly IMapper _mapper;
    
        public LibraryService(ILibraryRepository libraryRepository/*, IMapper mapper*/)
        {
            _libraryRepository = libraryRepository;
           // _mapper = mapper;
        }

        public async Task<Libraries> GetLibraryByIdAsync(int id)
        {
            var returnedLibrary = await _libraryRepository.GetLibraryByIdAsync(id);
            //return _mapper.Map<Libraries>(returnedLibrary);
            return returnedLibrary;
        }

        public async Task<IEnumerable<Libraries>> GetLibrariesAsync()
        {
            return await _libraryRepository.GetLibrariesAsync();
        }

    }
}