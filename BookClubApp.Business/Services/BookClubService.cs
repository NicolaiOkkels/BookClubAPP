using AutoMapper;
using BookClubApp.DataAccess.Entities;
using BookClubApp.DataAccess.Repositories;
using BookClubApp.Business.Services;


namespace BookClubApp.Business.Services
{
    public class BookClubService : IBookClubService
    {
        private readonly IBookClubRepository _bookClubRepository;
        //private readonly IMapper _mapper;
    
        public BookClubService(IBookClubRepository bookClubRepository/*, IMapper mapper*/)
        {
            _bookClubRepository = bookClubRepository;
           // _mapper = mapper;
        }

        public async Task<BookClub> CreateBookClubAsync(BookClub bookClub)
        {
            var createdBookClub = await _bookClubRepository.CreateBookClubAsync(bookClub);
            //return _mapper.Map<BookClub>(createdBookClub);
            return createdBookClub;

        }

        public Task DeleteBookClubAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BookClub> GetBookClubByIdAsync(int id)
        {
            var returnedBookClub = await _bookClubRepository.GetBookClubByIdAsync(id);
            //return _mapper.Map<BookClub>(returnedBookClub);
            return returnedBookClub;
        }

        public async Task<IEnumerable<BookClub>> GetBookClubsAsync()
        {
            return await _bookClubRepository.GetBookClubsAsync();
        }

        public async Task<BookClub> UpdateBookClubAsync(int id, BookClub bookClub)
        {
            var updatedBookClub = await _bookClubRepository.UpdateBookClubAsync(id, bookClub);
            return updatedBookClub;            
        }
    }
}