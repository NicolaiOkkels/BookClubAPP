using BookClubApp.Business.Services;
using BookClubApp.DataAccess.Entities;
using BookClubApp.DataAccess.Repositories;
using Moq;

namespace Unit_test
{
    public class LiberaryServiceTest
    {
        [Fact]
        public async Task GetLibraryByIdAsync_ReturnsLibrary()
        {
            // Arrange
            var mockRepository = new Mock<ILibraryRepository>();
            int libraryId = 1;
            var library = new Libraries { Id = libraryId, LibrarieNumber = 3, LibrarieName = "bibliotek 3", LibrarieAddress = "bibliotek St",LibrarieZipCode = 1234, LibrarieCity = "bibliotekby", PhoneNumber = "12311111", Email = "test@test.com" };

            mockRepository.Setup(repo => repo.GetLibraryByIdAsync(libraryId)).ReturnsAsync(library);
            var libraryService = new LibraryService(mockRepository.Object);

            // Act
            var result = await libraryService.GetLibraryByIdAsync(libraryId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(libraryId, result.Id);
        }
}
}
