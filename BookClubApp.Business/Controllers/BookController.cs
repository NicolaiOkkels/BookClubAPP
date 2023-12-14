using BookClubApp.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookClubApp.DataAccess.Entities;


namespace BookClubAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class BooksController : ControllerBase
{
    private readonly ISearchService _searchService;

    public BooksController(ISearchService searchService)
    {
        _searchService = searchService;
    }

    [HttpGet("getbooks")]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _searchService.GetBooksAsync();
        return Ok(books);
    }

    [HttpPost("addbook")]
    public async Task<IActionResult> AddBook(Book book)
    {
        var addedBook = await _searchService.AddBookAsync(book);
        return Ok(addedBook);
    }
}
