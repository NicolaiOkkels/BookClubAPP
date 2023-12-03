using BookClubApp.Business.Services;
using Xunit.Abstractions;

namespace Unit_test
{
    public class AuthServiceTests
    {
        [Fact]
        public void GenerateJwtToken_ValidToken()
        {
            // Arrange
            var authService = new AuthService();

            // Act
            var token = authService.GenerateJwtToken();

            // Assert
            Assert.NotNull(token);
        }

        [Fact]
        public void GenerateJwtToken_Greater_Than_0()
        {
            // Arrange
            var authService = new AuthService();

            // Act
            var token = authService.GenerateJwtToken();

            // Assert
            Assert.True(token.Length > 0);
        }
    }
}