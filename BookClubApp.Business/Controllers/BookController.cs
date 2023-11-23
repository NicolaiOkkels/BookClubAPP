using BookClubApp.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookClubAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly SearchService _searchService;

    public BooksController(SearchService openSearchService)
    {
        _searchService = openSearchService;
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return BadRequest("Query cannot be empty.");
        }

        var books = await _searchService.SearchBookAsync(query);
        return Ok(books);

    }

    [HttpGet("{identifier}")]
    public async Task<IActionResult> GetBook(string identifier)
    {
        if (string.IsNullOrWhiteSpace(identifier))
        {
            return BadRequest("Identifier cannot be empty.");
        }

        var book = await _searchService.GetBookByIdentifier(identifier);
        if (book == null)
        {
            return NotFound($"Book with identifier {identifier} not found.");
        }
        return Ok(book);
    }
}