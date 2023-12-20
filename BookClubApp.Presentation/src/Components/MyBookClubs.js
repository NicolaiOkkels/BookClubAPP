import React, { useEffect, useState, useCallback } from "react";
import { useAuth0 } from "@auth0/auth0-react";
import useAuthApi from "../hooks/useAuthApi";

const MyBookClubs = () => {
  const [myBookClubs, setMyBookClubs] = useState([]);
  const { user, isAuthenticated } = useAuth0();
  const api = useAuthApi();

  const fetchMyBookClubs = useCallback(async () => {
    if (!isAuthenticated || !user) return;
  
    try {
      const result = await api.get(`/BookClub/mybookclubs?email=${user.email}`);
      console.log(result.data);
      setMyBookClubs(result.data);
    } catch (error) {
      console.error("Error fetching my bookclubs", error);
    }
  }, [api, isAuthenticated, user, setMyBookClubs]); 

  useEffect(() => {
    (async () => {
      fetchMyBookClubs();
    })();
  }, [fetchMyBookClubs]);

  return (
    <div className="container">
      <h1>BookClubs</h1>
      {myBookClubs && myBookClubs.length > 0 ? (
        <div className="row">
          {myBookClubs.map((bookclub, index) => (
            <div className="col-sm-3 mb-3" key={index}>
              <div className="card">
                <img
                  src={`https://source.unsplash.com/200x300/?${bookclub.name}`}
                  alt="Book Club"
                  className="card-img-top"
                />
                <div className="card-body">
                  <h5 className="card-title">{bookclub.name}</h5>
                  <p className="card-text">{bookclub.description}</p>
                  <p className="card-text">
                    <strong>Type:</strong> {bookclub.type}
                  </p>
                  <p className="card-text">
                    <strong>Genre:</strong> {bookclub.genre}
                  </p>
                  <button className="btn btn-primary">Update</button>
                </div>
              </div>
            </div>
          ))}
        </div>
      ) : (
        <div
          className="d-flex justify-content-center align-items-center"
          style={{ height: "300px" }}
        >
          <p className="text-center">You are not part of any book club yet.</p>
        </div>
      )}
    </div>
  );
};

export default MyBookClubs;
