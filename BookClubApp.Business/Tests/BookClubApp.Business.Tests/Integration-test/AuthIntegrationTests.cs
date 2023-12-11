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
            // Generate a JWT token
            var token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6InBOcmdWT1pRby1FbDVUNF9rdjIyZSJ9.eyJpc3MiOiJodHRwczovL2Rldi1uMWVqZG5hNXJoYTF0YXhnLnVzLmF1dGgwLmNvbS8iLCJzdWIiOiJ5ZGZHNFRMUERyYjE2U1RsRE1rc3lhaWpvcWFRMFAwR0BjbGllbnRzIiwiYXVkIjoiaHR0cHM6Ly9hcGkuYm9va2NsdWIuY29tIiwiaWF0IjoxNzAyMzA5MzY5LCJleHAiOjE3MDIzOTU3NjksImF6cCI6InlkZkc0VExQRHJiMTZTVGxETWtzeWFpam9xYVEwUDBHIiwiZ3R5IjoiY2xpZW50LWNyZWRlbnRpYWxzIn0.N9sRLK5PRfGhdrudQ23tjRRAj-Nupq3U3NAHvTmRmAVUwyqf5H7n0UZNumN5TmaeUoQExr3USgUD09xvs7408V5_D58_Qfd0T7fjn0Ejcg0_mnDiun8UwawefGNCT-4SsbRYkMEs8lKo2az_v2ob4EzwLvHexeV1wKc8PVrSRcc0ILqu0IXmdP_VQlkvPi6-OMKdLY1WoM2btqEKHRbCcBfBfGowI-MN9kynDloG4QkjLZNPoEpqHI1IcYyfqun4WN4ViC0Vtsf3KBPnWcCrdkRoCDqKF1MC77q0Zba1fpjpbnKE0Zz0EwmiuS1tcxPDj-ILFOCFgNegL4RVJK-1dQ";

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