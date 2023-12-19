import React, { useState } from "react";
import { ApolloClient, InMemoryCache, createHttpLink, gql } from '@apollo/client';
import { setContext } from '@apollo/client/link/context';
import useAuthApi from "../hooks/useAuthApi";
 
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
 
const httpLink = createHttpLink({
  uri: 'https://fbi-api.dbc.dk/complex-search/graphql',
});
 
const authLink = setContext((_, { headers }) => {
  const token = process.env.REACT_APP_AUTH_TOKEN;
  return {
    headers: {
      ...headers,
      authorization: token ? `Bearer ${token}` : "",
    }
  }
});
 
const client = new ApolloClient({
  link: authLink.concat(httpLink),
  cache: new InMemoryCache()
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
  const api = useAuthApi();

  const handleSearch = () => {
    const formattedSearchString = `"${searchString}"`; // Wrap the searchString in quotes

    const variables = {
      cql: formattedSearchString,
      offset: 0,
      limit: 15,
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


  const handleSaveBook = async (book) => {
    try {
      const data = {
        Pid: book.manifestations.bestRepresentation.pid,
        Title: book.titles.full[0],
        Author: book.creators.map(creator => creator.display).join(', '),
        CoverImage: book.manifestations.bestRepresentation.cover.detail,
        MaterialType: book.manifestations.bestRepresentation.materialTypes.map(materialType => materialType.materialTypeGeneral.display).join(', ')
      };
  
      console.log('Data being sent to server:', data); // Log the data
  
      const response = await api.post('/Books/addbook', data, {
        headers: {
          'Content-Type': 'application/json',
        },
      });
  
      const responseData = response.data;
  
      // Update the savedBooks state with the new book
      setSavedBooks([...savedBooks, responseData]);
  
    } catch (error) {
      console.error('Error:', error);
      if (error.response) {
        console.log('Server response:', error.response.data); // Log the server response
      }
    }
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
          <div style={{ display: 'flex', flexWrap: 'wrap', justifyContent: 'space-evenly' }}>

            {searchResults.complexSearch.works.map((work, index) => (
              <div key={index}>
                <Card
                  title={work.titles.full[0]}
                  creator={work.creators.map(creator => creator.display).join(', ')}
                  cover={work.manifestations.bestRepresentation.cover.detail}
                  materialTypes={work.manifestations.bestRepresentation.materialTypes.map(materialType => materialType.materialTypeGeneral.display).join(', ')}
                  Pid={work.manifestations.bestRepresentation.pid}
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
