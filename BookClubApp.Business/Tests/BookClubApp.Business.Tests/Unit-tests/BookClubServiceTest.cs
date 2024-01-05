using BookClubApp.DataAccess.Repositories;
using BookClubApp.DataAccess.Entities;
using BookClubApp.Business.Services;
using Moq;

namespace Unit_test
{
    public class BookClubServiceTest
    {
        [Fact]
        public async Task GetBookClubsAsync_ReturnsAllBookClubs()
        {
            // Arrange
            var dummyBookClubRepository = new DummyBookClubRepository();
            var dummyMembershipRepository = new DummyMembershipRepository();
            var service = new BookClubService(dummyBookClubRepository, dummyMembershipRepository);

            // Act
            var result = await service.GetBookClubsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetBookClubByIdAsync_ReturnsBookClub()
        {
            // Arrange
            var mockRepository = new Mock<IBookClubRepository>();
            var mockMembershipRepository = new Mock<IMembershipRepository>();
            int testBookClubId = 1;
            var expectedBookClub = new BookClub { Id = testBookClubId, IsOpen = true, Name = "Test Club 1", Description = "Test Description", Type = "Test Type",LibrariesId = 1,
                Genre = "Test Genre" };

            mockRepository.Setup(repo => repo.GetBookClubByIdAsync(testBookClubId))
                        .ReturnsAsync(expectedBookClub);
            

            var service = new BookClubService(mockRepository.Object, mockMembershipRepository.Object);

            // Act
            var result = await service.GetBookClubByIdAsync(testBookClubId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedBookClub.Id, result.Id);
        }

        [Fact]
        public async Task UpdateBookClubAsync_UpdatesBookClubCorrectly()
        {
            // Arrange
            var mockRepository = new Mock<IBookClubRepository>();
            var mockMembershipRepository = new Mock<IMembershipRepository>();
            int testId = 1;
            var originalBookClub = new BookClub { Id = testId,  IsOpen = true, Name = "Test Club 1", Description = "Test Description", Type = "Test Type",LibrariesId = 1,
                Genre = "Test Genre" };
            var updatedBookClub = new BookClub { Id = testId,  IsOpen = true, Name = "Test Club 1", Description = "Test Description", Type = "Test Type",LibrariesId = 1,
                Genre = "Test Genre" };

            mockRepository.Setup(repo => repo.GetBookClubByIdAsync(testId))
                        .ReturnsAsync(originalBookClub);
            mockRepository.Setup(repo => repo.UpdateBookClubAsync(testId, updatedBookClub))
                        .ReturnsAsync(updatedBookClub);

            var service = new BookClubService(mockRepository.Object, mockMembershipRepository.Object);

            // Act
            var result = await service.UpdateBookClubAsync(testId, updatedBookClub);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(testId, result.Id);
        }
    }
}