using BookClubApp.DataAccess.Entities;
using BookClubApp.DataAccess.Repositories;

public class DummyBookClubRepository : IBookClubRepository
{
    private readonly List<BookClub> _bookClubs;

    public DummyBookClubRepository()
    {
        _bookClubs = new List<BookClub>
        {
            new BookClub { IsOpen = true, Name = "Test Club 1", Description = "Test Description", Type = "Test Type",LibrariesId = 1,
                Genre = "Test Genre" },
            new BookClub { IsOpen = true, Name = "Test Club 2", Description = "Test Description", Type = "Test Type",LibrariesId = 1,
                Genre = "Test Genre" }
        };
    }

    public Task<BookClub> CreateBookClubAsync(BookClub bookClub)
    {
        throw new NotImplementedException();
    }

    public Task DeleteBookClubAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<BookClub> GetBookClubByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BookClub>> GetBookClubsAsync()
    {
        return Task.FromResult(_bookClubs.AsEnumerable());
    }

    public Task<BookClub> UpdateBookClubAsync(int id, BookClub bookClub)
    {
        throw new NotImplementedException();
    }
}