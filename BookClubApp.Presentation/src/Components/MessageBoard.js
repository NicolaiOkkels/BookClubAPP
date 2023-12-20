import React, { useState, useEffect } from "react";
import useAuthApi from "../hooks/useAuthApi";
import { useAuth0 } from "@auth0/auth0-react";
import { Card, CardContent, Typography } from "@material-ui/core";

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
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          value={newMessage}
          onChange={(e) => setNewMessage(e.target.value)}
        />
        <button type="submit">Send</button>
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
