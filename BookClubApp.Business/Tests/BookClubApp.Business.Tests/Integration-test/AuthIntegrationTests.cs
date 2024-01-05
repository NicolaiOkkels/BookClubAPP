using System.Net;
using System.Net.Http.Headers;
using BookClubApp.Business.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;
using RestSharp;
using Newtonsoft.Json; // Add the missing using directive

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
            //var client = new RestClient("https://dev-n1ejdna5rha1taxg.us.auth0.com/oauth/token");
            //var request = new RestRequest
            //{
            //    Method = Method.Post
            //};
            //request.AddHeader("content-type", "application/json");
            //request.AddParameter("application/json", "{\"client_id\":\"ydfG4TLPDrb16STlDMksyaijoqaQ0P0G\",\"client_secret\":\"U_l2RTAdW67Junfn_-dW4tXMMx00Dbx0XN_t39k2N03V4J9FkupBXvVx3bptF2pv\",\"audience\":\"https://api.bookclub.com\",\"grant_type\":\"client_credentials\"}", ParameterType.RequestBody);
            //RestResponse tokenResponse = client.Execute(request);

            // Extract the token from the response
            //var jsonResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(tokenResponse.Content);
            //var token = jsonResponse.ContainsKey("access_token") ? jsonResponse["access_token"] : null;

            // Ensure that the token is not null or empty
            //Assert.False(string.IsNullOrEmpty(token), "JWT token is null or empty");

            // Use the token in your test client
            //var testClient = _factory.CreateClient();
            //using var scope = _factory.Services.CreateScope();

            //Set the JWT token in the Authorization header
            //testClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            //var response = await testClient.GetAsync(url);

            // Assert
            //response.EnsureSuccessStatusCode();
            //Assert.Equal(HttpStatusCode.OK, response.StatusCode);
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