using AutoMapper;
using BookClubApp.DataAccess.Entities;
using BookClubApp.DataAccess.Repositories;
using BookClubApp.Business.Services;


namespace BookClubApp.Business.Services
{
    public class BookClubService : IBookClubService
    {
        private readonly IBookClubRepository _bookClubRepository;
        private readonly IMembershipRepository _membershipRepository;

        public BookClubService(IBookClubRepository bookClubRepository, IMembershipRepository membershipRepository)
        {
            _bookClubRepository = bookClubRepository;
            _membershipRepository = membershipRepository;
        }
        public async Task<BookClub> CreateBookClubAsync(BookClub bookClub, int ownerId, int roleId)
        {
            var createdBookClub = await _bookClubRepository.CreateBookClubAsync(bookClub);

            var membership = new Membership
            {
                MemberId = ownerId,
                BookClubId = createdBookClub.Id,
                RoleId = roleId
            };

            await _membershipRepository.AddMembershipAsync(membership);

            return createdBookClub;
        }

        public async Task DeleteBookClubAsync(int id)
        {
            await _bookClubRepository.DeleteBookClubAsync(id);
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

        // public async Task<IEnumerable<BookClub>> GetBookClubsByEmailAsync(string email)
        // {
        //     return await _bookClubRepository.GetBookClubsByEmailAsync(email);
        // }

        public async Task<Membership> JoinBookClubAsync(int bookClubId, int memberId, int roleId)
        {
            var membership = new Membership
            {
                BookClubId = bookClubId,
                MemberId = memberId,
                RoleId = roleId
            };
            return await _membershipRepository.AddMembershipAsync(membership);
        }

        public async Task<BookClub> UpdateBookClubAsync(int id, BookClub bookClub)
        {
            var updatedBookClub = await _bookClubRepository.UpdateBookClubAsync(id, bookClub);
            return updatedBookClub;
        }
    }
}