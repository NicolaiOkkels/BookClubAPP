import { useEffect, useState, useCallback } from "react";
import useAuthApi from "../hooks/useAuthApi";
import Modal from "react-modal";
import { Card, Button } from 'react-bootstrap';
import { Score } from '../Enums/Score';
import { useAuth0 } from "@auth0/auth0-react";

const App = () => {
  const [books, setBooks] = useState([]);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [selectedBookIndex, setSelectedBookIndex] = useState(null);
  const api = useAuthApi();
  const { user } = useAuth0();

  const fetchRating = useCallback(async (book) => {
    const ratingResult = await api.get(`/Rating/avg/${book.id}`);
    return { ...book, rating: ratingResult.data };
  }, [api]);
  
  const fetchBooks = useCallback(async () => {
    const result = await api.get("/Books/getbooks");
    const booksWithScores = await Promise.all(result.data.map(fetchRating));
    setBooks(booksWithScores);
  }, [api, fetchRating, setBooks]); 

  useEffect(() => {
    fetchBooks();
    Modal.setAppElement("#root");
  }, [fetchBooks]);


  const saveRating = async () => {
    const book = books[selectedBookIndex];
    const memberResponse = await api.get(`/Member/getmemberbyemail?email=${user.email}`);
    const member = memberResponse.data;
    const score = Number(book.score);
    console.log("username is: ", member.name);

    if (isNaN(score) || score < 1 || score > 5) {
      console.log('Invalid score. Score must be a number between 1 and 5.');
      return;
    }

    const ratingData = {
      BookId: book.id,
      MemberId: member.id,
      Score: score
    };

    await api.post(`/Rating/AddRating`, ratingData);
    fetchBooks();
  }

  const deleteBook = async (bookId) => {
    await api.delete(`/Books/deletebook/${bookId}`);
    fetchBooks();
  }

  const handleScoreChange = (e) => {
    const newBooks = [...books];
    newBooks[selectedBookIndex].score = e.target.value || "";
    setBooks(newBooks);
  }

  const openModal = (index) => {
    setSelectedBookIndex(index);
    setIsModalOpen(true);
  }

  const closeModal = () => {
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
                <Card.Text>Rating: {book.rating}</Card.Text>

                <Button variant="primary" onClick={() => openModal(index)}>Add Rating</Button>
                <Button variant="danger" onClick={() => deleteBook(book.id)}>Delete Book</Button>
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