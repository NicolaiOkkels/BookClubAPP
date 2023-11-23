using System.Xml.Linq;
using BookClubApp.DataAccess.Entities;

namespace BookClubApp.Business.Services
{
    public class SearchService : ISearchService
    {

        private readonly HttpClient _httpClient;
        private string baseURL = "https://opensearch.addi.dk/test_5.2/";

        public async Task<Book> GetBookByIdentifier(string identifier)
        {
            var getObjectQuery = $"?action=getObject&identifier={identifier}&agency=100200&profile=test";
            var response = await _httpClient.GetAsync(baseURL + getObjectQuery);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            var content = await response.Content.ReadAsStringAsync();
            var xDoc = XDocument.Parse(content);
            var ns = xDoc.Root.GetDefaultNamespace();
            var xsi = "http://www.w3.org/2001/XMLSchema-instance";

            var record = xDoc.Descendants(ns + "record").FirstOrDefault();
            if (record == null)
            {
                return null;
            }

            var book = new Book
            {
                Identifier = record.Element(ns + "identifier")?.Value,
                ISBN = record.Elements(ns + "identifier")
                            .FirstOrDefault(id => (string)id.Attribute(XNamespace.Get(xsi) + "type") == "dkdcplus:ISBN")?.Value,
                Title = record.Elements(ns + "title")
                            .FirstOrDefault(t => t.Attribute(XNamespace.Get(xsi) + "type") == null)?.Value,
                Description = record.Element(ns + "description")?.Value,
                Publisher = record.Element(ns + "publisher")?.Value,
                PublicationYear = ParsePublicationYear(record, ns),
                Language = record.Elements(ns + "language")
                                .FirstOrDefault(lang => lang.Attribute(XNamespace.Get(xsi) + "type") == null)?.Value,
                Pages = record.Element(ns + "extent")?.Value
            };

            return book;
        }

        public async Task<IEnumerable<Book>> SearchBookAsync(string query)
        {
            var searchQuery = String.Format($"?action=search&query=\"{query}\"&agency=100200&profile=test&start=1&stepValue=5");
            var response = await _httpClient.GetAsync(baseURL + searchQuery);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            var content = await response.Content.ReadAsStringAsync();
            var xDoc = XDocument.Parse(content);
            var ns = xDoc.Root?.GetDefaultNamespace();
            var xsi = "http://www.w3.org/2001/XMLSchema-instance";

            var books = xDoc.Descendants(ns + "record")
                            .Select(record => new Book
                            {
                                Identifier = record.Element(ns + "identifier")?.Value,
                                ISBN = record.Elements(ns + "identifier")
                                            .FirstOrDefault(id => (string?)id.Attribute(XNamespace.Get(xsi) + "type") == "dkdcplus:ISBN")?.Value,
                                Title = record.Elements(ns + "title")
                                            .FirstOrDefault(t => t.Attribute(XNamespace.Get(xsi) + "type") == null)?.Value,
                                Description = record.Element(ns + "description")?.Value,
                                Publisher = record.Element(ns + "publisher")?.Value,
                                PublicationYear = ParsePublicationYear(record, ns),
                                Language = record.Elements(ns + "language")
                                                .FirstOrDefault(lang => lang.Attribute(XNamespace.Get(xsi) + "type") == null)?.Value,
                                Pages = record.Element(ns + "extent")?.Value
                            })
                            .ToList();

            return books;
        }

        private int ParsePublicationYear(XElement record, XNamespace ns)
        {
            var yearString = record.Element(ns + "date")?.Value;
            if (int.TryParse(yearString, out int year))
            {
                return year;
            }
            return 0;
        }
    }
}