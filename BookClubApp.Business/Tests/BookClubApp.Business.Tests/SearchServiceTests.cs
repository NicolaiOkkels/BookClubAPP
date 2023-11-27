using System.Net;
using System.Net.Http.Headers;
using BookClubApp.Business.Services;
using Moq;

namespace Unit_test
{
    public class SearchServiceTests
    {
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;
        private readonly SearchService _service;

        public SearchServiceTests()
        {
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            var httpClient = new HttpClient(_mockHttpMessageHandler.Object);
            _service = new SearchService(httpClient);
        }

        [Fact]
        public async Task GetBookByIdentifier_ReturnsBook_WhenResponseIsValid()
        {
            // Arrange
            var identifier = "28692765|870970";
            var validXmlResponse = GetValidBookXmlResponse();
            
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(validXmlResponse)
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");

            _mockHttpMessageHandler.Setup(x => x.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var book = await _service.GetBookByIdentifier(identifier);

            // Assert
            Assert.NotNull(book);
            Assert.Equal("28692765|870970", book.Identifier); // Example assertion, adjust as needed
        }

        private string GetValidBookXmlResponse()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetBookByIdentifier_ReturnsNull_WhenNoBookFound()
        {
            // Act & Assert
            Assert.Null(await _service.GetBookByIdentifier("nonexistentIdentifier"));
        }

        [Fact]
        public void GetBookByIdentifier_ThrowsException_WhenResponseIsUnsuccessful()
        {
            // Arrange
            _mockHttpClient.Setup(client => client.GetAsync(It.IsAny<string>()))
                        .ReturnsAsync(new HttpResponseMessage
                        {
                            StatusCode = HttpStatusCode.InternalServerError
                        });

            // Act & Assert
            Assert.ThrowsAsync<Exception>(() => _service.GetBookByIdentifier("123"));
        }

        private string GetValidXmlResponse()
        {
            return @"
            <SOAP-ENV:Envelope xmlns:SOAP-ENV='http://schemas.xmlsoap.org/soap/envelope/' xmlns:ac='http://biblstandard.dk/ac/namespace/' xmlns:dc='http://purl.org/dc/elements/1.1/' xmlns:dcterms='http://purl.org/dc/terms/' xmlns:dkabm='http://biblstandard.dk/abm/namespace/dkabm/' xmlns:dkdcplus='http://biblstandard.dk/abm/namespace/dkdcplus/' xmlns:oss='http://oss.dbc.dk/ns/osstypes' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns='http://oss.dbc.dk/ns/opensearch'>
                <SOAP-ENV:Body>
                    <searchResponse>
                        <result>
                            <!-- Mocked search results here -->
                            <searchResult>
                                <collection>
                                    <object>
                                        <dkabm:record>
                                            <ac:identifier>MockIdentifier|870970</ac:identifier>
                                            <dc:identifier xsi:type='dkdcplus:ISBN'>9781234567890</dc:identifier>
                                            <dc:title>Mock Title</dc:title>
                                            <dc:creator xsi:type='dkdcplus:aut'>Mock Author</dc:creator>
                                            <dcterms:abstract>Mock abstract description of the book content.</dcterms:abstract>
                                            <dc:publisher>Mock Publisher</dc:publisher>
                                            <dc:date>2023</dc:date>
                                            <dcterms:extent>300 sider</dcterms:extent>
                                            <dc:language>dansk</dc:language>
                                        </dkabm:record>
                                    </object>
                                </collection>
                            </searchResult>
                        </result>
                    </searchResponse>
                </SOAP-ENV:Body>
            </SOAP-ENV:Envelope>";
        }

    }
}