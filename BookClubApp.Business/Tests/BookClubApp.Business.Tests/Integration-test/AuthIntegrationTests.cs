using System.Net;
using System.Net.Http.Headers;
using BookClubApp.Business.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace Integration_test
{
    public class AuthIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        /// <summary>
        /// https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-7.0
        /// </summary>
        /// <param name="factory"></param>
        public AuthIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("BookClub/getclubs")] //TODO: Add all endpoints
        public async Task AuthorizedEndpoint_ReturnsSuccess(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            using var scope = _factory.Services.CreateScope();
            var authService = scope.ServiceProvider.GetRequiredService<IAuthService>();
            // Generate a JWT token
            var token = authService.GenerateJwtToken();

            //Set the JWT token in the Authorization header
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("/BookClub/getclubs")] //TODO: Add all endpoints
        public async Task UnauthorizedEndpoint_ReturnsUnauthorized(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}