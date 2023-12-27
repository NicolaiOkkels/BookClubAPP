import React, { useState, useEffect } from "react";
import useAuthApi from "../hooks/useAuthApi";
import { useAuth0 } from "@auth0/auth0-react";
import { Card, CardContent, Typography } from "@material-ui/core";
import 'bootstrap/dist/css/bootstrap.min.css';

function MessageBoard({ bookClubId }) {
  const [messages, setMessages] = useState([]);
  const [newMessage, setNewMessage] = useState("");
  const api = useAuthApi();
  const { user } = useAuth0();

  useEffect(() => {
    const fetchMessages = async () => {
      try {
        const result = await api.get(
          `/Message/getmessages?bookClubId=${bookClubId}`
        );
        setMessages(result.data);
      } catch (error) {
        console.error("Failed to fetch messages:", error);
      }
    };

    fetchMessages();
  }, [api, bookClubId]);

  const handleSubmit = async (event) => {
    event.preventDefault();

    try {
      const memberResponse = await api.get(
        `/Member/getmemberbyemail?email=${user.email}`
      );
      const member = memberResponse.data;

      const response = await api.post("/Message/AddMessage", {
        content: newMessage,
        userName: member.name,
        date: new Date().toISOString(),
        bookClubId: bookClubId,
      });

      setMessages([response.data, ...messages]);
      setNewMessage("");
    } catch (error) {
      console.error("Failed to save message:", error);
    }
  };

  return (
    <div>
      <form onSubmit={handleSubmit} className="input-group mb-3">
        <input
          type="text"
          value={newMessage}
          onChange={(e) => setNewMessage(e.target.value)}
          className="form-control"
          placeholder="Enter your message"
          aria-label="Recipient's username"
          aria-describedby="button-addon2"
        />
        <button
          className="btn btn-outline-secondary"
          type="submit"
          id="button-addon2"
        >
          Send
        </button>
      </form>
      {messages.map((message) => (
        <Card key={message.id}>
          <CardContent>
            <Typography color="textSecondary" gutterBottom>
              {message.userName}
            </Typography>
            <Typography variant="body2" component="p">
              {message.content}
            </Typography>
            <Typography color="textSecondary">
              {new Date(message.date).toLocaleString()}
            </Typography>
          </CardContent>
        </Card>
      ))}
    </div>
  );
}

export default MessageBoard;
