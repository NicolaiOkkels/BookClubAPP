using BookClubApp.DataAccess.Data;
using BookClubApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookClubApp.DataAccess.Repositories
{
    public class PollRepository : IPollRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PollRepository> _logger;

        public PollRepository(ApplicationDbContext context, ILogger<PollRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

public async Task<Poll> CreatePollAsync(Poll poll, List<int> bookIds)
{
    // Check if the BookClubId exists in the BookClubs table
    var bookClubExists = await _context.BookClubs.AnyAsync(bc => bc.Id == poll.BookClubId);
    if (!bookClubExists)
    {
        throw new Exception($"No book club found with ID {poll.BookClubId}");
    }

    // Fetch the books from the database
    var books = await _context.Books.Where(b => bookIds.Contains(b.Id)).ToListAsync();

    // Detach the poll entity
    _context.Entry(poll).State = EntityState.Detached;

    // Create PollBook entities from the books and add them to the poll
    foreach (var book in books)
    {
        var existingPollBook = await _context.PollBook
            .Where(pb => pb.PollId == poll.Id && pb.BookId == book.Id)
            .FirstOrDefaultAsync();

        if (existingPollBook == null)
        {
            // Add new PollBook
            var newPollBook = new PollBook { Poll = poll, Book = book };
            poll.PollBooks.Add(newPollBook);
        }
    }

    _context.Polls.Add(poll);
    await _context.SaveChangesAsync();
    return poll;
}

        public async Task<Poll> GetPollAsync(int id)
        {
            var poll = await _context.Polls.FindAsync(id);
            if (poll == null)
            {
                throw new Exception($"No poll found with ID {id}");
            }
            return poll;
        }

        public async Task DeletePollAsync(int id)
        {
            var poll = await _context.Polls.FindAsync(id);
            if (poll == null)
            {
                throw new Exception($"No poll found with ID {id}");
            }
            _context.Polls.Remove(poll);
            await _context.SaveChangesAsync();
        }

        public async Task<Poll> GetPollByIdAsync(int id)
        {
            var poll = await _context.Polls
                .Include(p => p.PollBooks)
                .ThenInclude(pb => pb.Book)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (poll == null)
            {
                throw new Exception($"No poll found with ID {id}");
            }
            return poll;
        }

        public async Task<IEnumerable<Poll>> GetPollsAsync()
        {
            return await _context.Polls
                .Include(p => p.PollBooks)
                .ThenInclude(pb => pb.Book)
                .ToListAsync();
        }
    }
}