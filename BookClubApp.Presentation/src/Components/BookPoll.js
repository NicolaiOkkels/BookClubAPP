import React, { useState } from 'react';

const BookPoll = ({ books, totalVotes, setTotalVotes }) => {
    const [votes, setVotes] = useState({});
    const [hasVoted, setHasVoted] = useState(false);

    const handleVote = (book) => {
        if (!hasVoted) {
            setVotes((prevVotes) => ({
                ...prevVotes,
                [book.title]: prevVotes[book.title] ? prevVotes[book.title] + 1 : 1
            }));
            setHasVoted(true);
            setTotalVotes(totalVotes + 1);
        }
    };

    const resetVotes = () => {
        setVotes({});
        setHasVoted(false);
        setTotalVotes(0);
    };

    return (
        <div>
            <h2>Book Poll</h2>
            {books.map((book, index) => (
                <div key={index}>
                    <button disabled={hasVoted} onClick={() => handleVote(book)}>Vote for {book.title}</button>
                    <p>{votes[book.title] || 0} votes</p>
                </div>
            ))}
            <p>Total votes for all books: {totalVotes} </p>
            <button onClick={resetVotes}>Reset Votes</button>
        </div>
    );
};

export default BookPoll;