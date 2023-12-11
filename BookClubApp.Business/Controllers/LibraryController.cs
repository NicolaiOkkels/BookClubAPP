using BookClubApp.Business.Services;
using BookClubApp.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookClubApp.Business.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]

public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet("getlibraries")]
        public async Task<IActionResult> GetLibraries()
        {
            var libraries = await _libraryService.GetLibrariesAsync();
            return Ok(libraries);
        }

        [HttpGet("getlibrary/{id}")]
        public async Task<IActionResult> GetLibraryById(int id)
        {
            var library = await _libraryService.GetLibraryByIdAsync(id);
            return Ok(library);
        }


}
}