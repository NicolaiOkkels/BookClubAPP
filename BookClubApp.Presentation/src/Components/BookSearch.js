import React, { useState } from "react";
import ApolloClient, { gql } from "apollo-boost";


// Define your Card component
const Card = ({ title, creator, cover, materialTypes }) => (
  <div style={{
    border: '1px solid #ddd',
    borderRadius: '4px',
    padding: '10px',
    margin: '10px',
    maxWidth: '200px',
    boxShadow: '0 4px 8px 0 rgba(0,0,0,0.2)',
    transition: '0.3s',
  }}>
    <img src={cover} alt="Cover" style={{
      width: '100%',
      borderRadius: '4px 4px 0 0',
    }} />
    <div style={{
      padding: '2px 16px',
    }}>
      <h3>{title}</h3>
      <p>{creator}</p>
      <p>{materialTypes}</p>
    </div>
  </div>
);

const client = new ApolloClient({
  uri: 'https://fbi-api.dbc.dk/complex-search/graphql',
  request: operation => {
    const token = process.env.REACT_APP_AUTH_TOKEN; // replace with your actual token
    operation.setContext({
      headers: {
        Authorization: token ? `Bearer ${token}` : ''
      }
    });
  }
});

const SEARCH_QUERY = gql`
  query ($cql: String!, $offset: Int!, $limit: PaginationLimit!, $filters: ComplexSearchFilters!) {
    complexSearch(cql: $cql, filters: $filters) {
      hitcount
      works(offset: $offset, limit: $limit) {
        titles {
          full
        }
        creators {
          display
        }
        manifestations {
          bestRepresentation {
            cover
            {detail}
            pid
            materialTypes {
              materialTypeGeneral {
                display
              }
            }
          }
        }
      }
    }
  }
`;

const BookSearch = () => {
  const [searchString, setSearchString] = useState("");
  const [searchResults, setSearchResults] = useState(null);
  // Add a new state variable to hold the saved books
const [savedBooks, setSavedBooks] = useState([]);

  const handleSearch = () => {
    const formattedSearchString = `"${searchString}"`; // Wrap the searchString in quotes
  
    const variables = {
      cql: formattedSearchString,
      offset: 0,
      limit: 10,
      filters: {},
    };

    client
      .query({ query: SEARCH_QUERY, variables })
      .then((response) => {
        console.log(response.data);
        setSearchResults(response.data);
      })
      .catch((error) => console.error(error));
  };


  // Add a new function to handle saving a book
const handleSaveBook = (book) => {
  // Send a request to your server to save the book in your database
  // This will depend on how your server is set up
  fetch('/api/saveBook', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(book),
  })
  .then(response => response.json())
  .then(data => {
    // Update the savedBooks state with the new book
    setSavedBooks([...savedBooks, data]);
  })
  .catch((error) => {
    console.error('Error:', error);
  });
};

  const handleFormSubmit = (e) => {
    e.preventDefault(); // Prevent the form from refreshing the page
    handleSearch();
  };
  return (
    <div>
      <form onSubmit={handleFormSubmit}>
        <input
          type="text"
          name="search"
          value={searchString}
          onChange={(e) => setSearchString(e.target.value)}
        />
        <button type="submit">Search</button>
      </form>
      {searchResults && searchResults.complexSearch && searchResults.complexSearch.works && (
        <div>
        <h2>Search Results:</h2>
        <div style={{display: 'flex', flexWrap: 'wrap', justifyContent: 'space-evenly'}}>
          
        {searchResults.complexSearch.works.map((work, index) => (
  <div key={index}>
    <Card 
      title={work.titles.full[0]} 
      creator={work.creators.map(creator => creator.display).join(', ')} 
      cover={work.manifestations.bestRepresentation.cover.detail}
      materialTypes={work.manifestations.bestRepresentation.materialTypes.map(materialType => materialType.materialTypeGeneral.display).join(', ')}
    />
    <button onClick={() => handleSaveBook(work)}>Save</button>
  </div>
          ))}
        </div>
        </div>
      )}
    </div>
  );
}

export default BookSearch;
