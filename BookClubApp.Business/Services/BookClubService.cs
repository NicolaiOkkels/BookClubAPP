using BookClubApp.DataAccess.Entities;
using BookClubApp.DataAccess.Repositories;


namespace BookClubApp.Business.Services
{
    public class BookClubService : IBookClubService
    {
        private readonly IBookClubRepository _bookClubRepository;
        public BookClubService(IBookClubRepository bookClubRepository)
        {
            _bookClubRepository = bookClubRepository;
        }

        public async Task<IEnumerable<BookClub>> GetBookClubsAsync()
        {
            return await _bookClubRepository.GetBookClubsAsync();
        }
    }
}