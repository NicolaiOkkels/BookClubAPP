using BookClubApp.Business.Services;
using BookClubApp.DataAccess.Entities;
using BookClubApp.DataAccess.Repositories;
using Moq;

namespace Unit_test
{
    
    public class MessageServiceTest
    {
        [Fact]
        public async Task AddMessageAsync_ReturnsAddedMessage()
        {
            // Arrange
            var mockRepository = new Mock<IMessageRepository>();
            var newMessage = new Message {  Content = "This is a message", UserName = "User1", Date = DateTime.Now, BookClubId = 1};
            var expectedMessage = new Message { Content = "This is a message", UserName = "User1", Date = DateTime.Now, BookClubId = 1};

            mockRepository.Setup(repo => repo.AddMessageAsync(It.IsAny<Message>())).ReturnsAsync(expectedMessage);
            var service = new MessageService(mockRepository.Object);

            // Act
            var result = await service.AddMessageAsync(newMessage);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMessage, result);
        }
    }
}
