import React, { useState, useEffect } from 'react';
import MessageBoard from './MessageBoard'; // Adjust the path based on where MessageBoard is located
import useAuthApi from "../hooks/useAuthApi";

const Home = () => {
  const [selectedBookClub, setSelectedBookClub] = useState(null);
  const [bookClubs, setBookClubs] = useState([]);
  const api = useAuthApi();

  useEffect(() => {
    const fetchBookClubs = async () => {
      try {
        const result = await api.get("/BookClub/getclubs");
        setBookClubs(result.data);
      } catch (error) {
        console.error('Failed to fetch book clubs:', error);
      }
    }

    fetchBookClubs();
  }, [api]);

  const handleBookClubSelect = (event) => {
    const bookClubId = Number(event.target.value);
    const bookClub = bookClubs.find(bc => bc.id === bookClubId);
    setSelectedBookClub(bookClub);
    console.log("selectedBookClub: ", bookClubId);
  };


  return (
    <div>
      <h1>Hello, world!</h1>
      <p>Welcome to your new single-page application, built with:</p>
      <select onChange={handleBookClubSelect}>
        <option value="">Select a book club</option>
        {bookClubs.map(bookClub => (
          <option key={bookClub.id} value={bookClub.id}>{bookClub.name}</option>
        ))}
      </select>
      {selectedBookClub && <MessageBoard bookClubId={selectedBookClub.id} />}
    </div>
  );
}

export default Home;