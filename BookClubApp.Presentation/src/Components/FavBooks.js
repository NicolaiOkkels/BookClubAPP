import { useEffect, useState } from "react";
import useAuthApi from "../hooks/useAuthApi";
import Modal from "react-modal";
import { Card, Button } from 'react-bootstrap';
import { Score } from '../Enums/Score';

const App = () => {
  const [books, setBooks] = useState([]);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [selectedBookIndex, setSelectedBookIndex] = useState(null);
  const api = useAuthApi();

  useEffect(() => {
    (async () => {
      await ListBooks();
    })();
    Modal.setAppElement("#root");
  }, []);

  async function ListBooks() {
    const result = await api.get("/Books/getbooks");
    const booksWithScores = await Promise.all(result.data.map(async book => {
      const ratingResult = await GetRatingById(book.id);
      return { ...book, rating: ratingResult };
    }));
    setBooks(booksWithScores);
    console.log("showing books: ", booksWithScores);
  }
  async function saveRating() {
    const book = books[selectedBookIndex];
    const result = await api.put(`/Books/updatebook/${book.id}`, book);
    console.log(`Saved rating for ID ${book.id}: `, result.data);
    ListBooks();
  }

  async function GetRatingById(id) {
    const result = await api.get(`/Rating/avg/${id}`);
    console.log(`Showing rating for ID ${id}: `, result.data);
  }

  function handleScoreChange(e) {
    const newBooks = [...books];
    newBooks[selectedBookIndex].score = e.target.value || "" ;
    setBooks(newBooks);
  }

  function openModal(index) {
    setSelectedBookIndex(index);
    setIsModalOpen(true);
  }

  function closeModal() {
    setIsModalOpen(false);
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
                <Card.Text>Rating: {book.score}</Card.Text>
  
                <Button variant="primary" onClick={() => openModal(index)}>Add Rating</Button>
              </Card.Body>
            </Card>
          </div>
        ))}
      </div>
      <Modal isOpen={isModalOpen} onRequestClose={closeModal}>
  <h2>Add Rating</h2>
  <select 
    name={`book-score-${selectedBookIndex}`} 
    value={books[selectedBookIndex]?.score ?? ""} 
    onChange={handleScoreChange}
  >
    <option value="" disabled>Select Score</option>
    {Object.entries(Score).map(([key, value]) => (
      <option key={key} value={value}>{value}</option>
    ))}
  </select>
  <Button variant="primary" onClick={() => { saveRating(); closeModal(); }}>Save Rating</Button>
</Modal>
    </div>
  );
};

export default App;