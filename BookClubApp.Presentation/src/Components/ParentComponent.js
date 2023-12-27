import React, { useState } from 'react';
import FavBooks from './FavBooks';
import BookPoll from './BookPoll';

const ParentComponent = () => {
    const [selectedBooks, setSelectedBooks] = useState([]);
    const [totalVotes, setTotalVotes] = useState(0);

    const handleSelectBook = (book) => {
        setSelectedBooks(prevBooks => [...prevBooks, book]);
    };

    return (
        <div>
            <FavBooks onSelectBook={handleSelectBook} />
            {selectedBooks.map((book, index) => (
                <div key={index}>
                    <h3>{book.title}</h3>
                    <BookPoll book={book} totalVotes={totalVotes} setTotalVotes={setTotalVotes} />
                </div>
            ))}
        </div>
    );
};

export default ParentComponent;