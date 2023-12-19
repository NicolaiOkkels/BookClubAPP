using System.Xml.Linq;
using BookClubApp.DataAccess.Entities;
using BookClubApp.DataAccess.Repositories;

namespace BookClubApp.Business.Services
{
    public class SearchService : ISearchService
    {
        private readonly IBookRepository _bookRepository;

        public SearchService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task DeleteBookAsync(Book book)
        {
            await _bookRepository.DeleteBookAsync(book);   
        }

        public async Task<Book> GetBookByIdentifierAsync(int id)
        {
            return await _bookRepository.GetBookByIdentifierAsync(id);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _bookRepository.GetBooksAsync();
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            var addedBook = await _bookRepository.AddBookAsync(book);
            return addedBook;
        }

        public async Task<Book> UpdateBookAsync(int id, Book book)
        {
            var updatedBook = await _bookRepository.UpdateBookAsync(id, book);
            return updatedBook;
        }

        public async Task SaveChangesAsync()
        {
            await _bookRepository.SaveChangesAsync();
        }
    }
}