import { useEffect, useState } from "react";
import useAuthApi from "../hooks/useAuthApi";
import Modal from "react-modal";
import { Card, Button } from 'react-bootstrap'; // Import Card and Button from react-bootstrap

const App = () => {
  const [books, setBooks] = useState([]);
  const api = useAuthApi();

  useEffect(() => {
    (async () => {
      await ListBooks();
    })();
    Modal.setAppElement("#root");
  }, []);

  async function ListBooks() {
    const result = await api.get("/Books/getbooks");
    setBooks(result.data);
    console.log("showing books: ",result.data);
  }

  return (
    <div className="container">
      <div className="row">
        {books.map((book, index) => (
          <div className="col-sm-4" key={index}>
            <Card style={{ width: '18rem' }}>
              <Card.Img variant="top" src={book.coverImage} />
              <Card.Body>
                <Card.Title>{book.title}</Card.Title>
                <Card.Text>{book.author}</Card.Text>
                <Button variant="primary">Go somewhere</Button>
              </Card.Body>
            </Card>
          </div>
        ))}
      </div>
    </div>
  );
};

export default App;