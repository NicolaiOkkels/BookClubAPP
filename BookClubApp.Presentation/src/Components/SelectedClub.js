import React, { useState, useEffect, useCallback } from "react";
import { useLocation } from "react-router-dom";
import MessageBoard from "./MessageBoard";
import Modal from "react-modal";
import FavBooks from "./FavBooks"; // import FavBooks
import BookPoll from "./BookPoll";
import "../bookPoll.css";
import useAuthApi from "../hooks/useAuthApi";

const SelectedClub = ({ bookClubId }) => {
  const location = useLocation();
  const selectedClub = location.state.selectedClub;
  const [isPollModalOpen, setPollIsModalOpen] = useState(false);
  const [selectedBooks, setSelectedBooks] = useState([]);
  const [totalVotes, setTotalVotes] = useState(0);
  const[poll, setPolls] = useState([]);
  const api = useAuthApi();

  const getPolls = useCallback(async () => {
    try {
      const response = await api.get('/Poll/getpolls');
      setPolls(response.data); // store the polls in the state
    } catch (error) {
      console.error(error);
    }
  }, []); 

  const addPoll = useCallback(async (poll) => {
    try {
      const response = await api.post('/Poll/addpoll', poll);
      console.log(response.data); // log the added poll
    } catch (error) {
      console.error(error);
    }
  }, [api]); // add the dependencies here

  useEffect(() => {
    getPolls();
  }, [getPolls]);



  const onSelectBook = async (book) => {
    if (selectedBooks.length < 3 && !selectedBooks.includes(book)) {
      const newSelectedBooks = [...selectedBooks, book];
      setSelectedBooks(newSelectedBooks);
      if (newSelectedBooks.length === 3) {
        closeModal();
        if (selectedClub.id === 0) {
          console.error('Invalid book club ID');
          return;
        }
        const poll = {
            BookClubId: selectedClub.id, // replace with the actual book club ID
            //Books: newSelectedBooks // assuming selectedBooks is an array of Book objects
            PollBooks: newSelectedBooks.map(book => ({ BookId: book.id }))
        };
        console.log("poll object: ",poll);
        await addPoll(poll);
      }
    }
  };

  const openModal = () => {
    setPollIsModalOpen(true);
  };

  const closeModal = () => {
    setPollIsModalOpen(false);
  };

  return (
    <div>
      <h1>Welcome to {selectedClub.name}'s bookclub</h1>
      {selectedClub && <MessageBoard bookClubId={selectedClub.id} />}
      <button onClick={openModal}>Create Book Poll</button>
      <Modal
        isOpen={isPollModalOpen}
        onRequestClose={closeModal}
        shouldFocusAfterRender={true}
        shouldCloseOnOverlayClick={false}
      >
        <FavBooks
          onSelectBook={onSelectBook}
          showAddToPoll={true}
          isPollModalOpen={isPollModalOpen}
        />
        <button onClick={closeModal}>Close</button>
      </Modal>

      <div className="book-list">
        {selectedBooks.map((book, index) => (
          <div key={index} className="book-card">
            <h3>{book.title}</h3>
            <img variant="top" src={book.coverImage} alt={book.title} />
          </div>
        ))}
        <BookPoll
          books={selectedBooks}
          totalVotes={totalVotes}
          setTotalVotes={setTotalVotes}
        />
      </div>
      <h2>Existing Polls:</h2>
    {poll.map((pollItem, index) => (
      <div key={index}>
        <h3>Poll {index + 1}</h3>
        {/* Render the properties of the pollItem here */}
        <p>BookClubId: {pollItem.BookClubId}</p>
        {/* If Books is an array of book objects, map over it to render each book */}
        {pollItem.Books && pollItem.Books.map((book, bookIndex) => (
          <p key={bookIndex}>Book {bookIndex + 1}: {book.title} {/* Replace 'title' with the actual property name */}</p>
        ))}
      </div>
    ))}
    </div>
  );
};

export default SelectedClub;
