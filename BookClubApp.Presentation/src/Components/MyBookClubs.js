import React, { useState, useEffect, useCallback } from "react";
import { useAuth0 } from "@auth0/auth0-react";
import useAuthApi from "../hooks/useAuthApi";
import { Genre } from "../Enums/Genre";
import { ClubType } from "../Enums/ClubType";
import { Formik, Field, Form } from "formik";
import Modal from "react-modal";

const MyBookClubs = () => {
  const [myBookClubs, setMyBookClubs] = useState([]);
  const { user, isAuthenticated } = useAuth0();
  const api = useAuthApi();
  const [isUpdateModalOpen, setIsUpdateModalOpen] = useState(false);
  const [currentClub, setCurrentClub] = useState({});
  const [libraries, setLibraries] = useState([]);

  const fetchMyBookClubs = useCallback(async () => {
    if (!isAuthenticated || !user) return;
    try {
      const membershipsResult = await api.get(
        `/Membership/mymemberships?email=${user.email}`);
      const memberships = membershipsResult.data;
      console.log("my memberships: ", memberships);
      const combinedData = memberships
        .map((membership) => {
          const bookClub = membership.bookClub;
          if (bookClub) {
            return {
              ...bookClub,
              role: membership.role,};}
          return null;
        })
        .filter((bookClub) => bookClub !== null);
      setMyBookClubs(combinedData);
    } catch (error) {
      console.error("Error fetching my bookclubs and memberships", error);
    }
  }, [api, isAuthenticated, user, setMyBookClubs]);

  const ListLibraries = useCallback(async () => {
    const result = await api.get("/Library/getlibraries");
    setLibraries(result.data);
  }, [api, setLibraries]); // Add any dependencies here

  useEffect(() => {
    fetchMyBookClubs();
    ListLibraries();
  }, [fetchMyBookClubs, ListLibraries]);

  async function UpdateClub(id, values) {
    try {
      values.librariesId = Number(values.librariesId);
      await api.put(`/BookClub/updateclub/${id}`, values);
      console.log("the values being sent to server: ", values);

      alert("Club updated successfully");
      fetchMyBookClubs();
      setIsUpdateModalOpen(false);
    } catch (error) {
      console.error(error);
      alert("Error updating club");
    }
  }

  const deleteBookClub = async (id) => {
    try {
      await api.delete(`/BookClub/deleteclub/${id}`);
      fetchMyBookClubs(); // Refresh the list of book clubs
    } catch (error) {
      console.error(`Error deleting book club with id ${id}`, error);
    }
  };
  async function leaveClub(bookclub) {
    try {
      const memberIdResponse = await api.get(`/Member/getmemberid?email=${user?.email}`);
      console.log("memberIdResponse: ", memberIdResponse);
      const memberId = memberIdResponse.data;
  
      if (!memberId) {
        throw new Error("Member ID not found");
      }
  
      await api.post(`/Membership/leaveclub/${bookclub.id}/${memberId}`);
      alert("Left club successfully");
      fetchMyBookClubs();
    } catch (error) {
      console.error(error);
      alert("Error leaving club");
    }
  }

  return (
    <div className="container">
      <h1>BookClubs</h1>
      {myBookClubs && myBookClubs.length > 0 ? (
        <div className="row">
          <Modal isOpen={isUpdateModalOpen}>
            <button onClick={() => setIsUpdateModalOpen(false)}>Close</button>
            <Formik
              initialValues={{
                name: currentClub.name,
                description: currentClub.description,
                type: currentClub.type,
                librariesId: currentClub.librariesId,
                genre: currentClub.genre,
                isOpen: currentClub.isOpen,
              }}
              onSubmit={(values) => UpdateClub(currentClub.id, values)}
            >
              <Form>
                <div className="form-group">
                  <label>BookClub Name</label>
                  <Field
                    type="text"
                    className="form-control"
                    id="name"
                    name="name"
                  />
                </div>
                <div className="form-group">
                  <label>BookClub Description</label>
                  <Field
                    type="text"
                    className="form-control"
                    id="description"
                    name="description"
                  />
                </div>
                <div className="form-group">
                  <label>BookClub Type</label>
                  <Field
                    as="select"
                    className="form-control"
                    id="type"
                    name="type"
                  >
                    <option value="" disabled>
                      Select Club type
                    </option>
                    {Object.entries(ClubType).map(([key, value]) => (
                      <option key={key} value={value}>
                        {value}
                      </option>
                    ))}
                  </Field>
                </div>
                <div className="form-group">
                  <label>Library</label>
                  <Field
                    as="select"
                    className="form-control"
                    id="librariesId"
                    name="librariesId"
                  >
                    <option value="" disabled>
                      Select Library
                    </option>
                    {libraries.map((library, index) => (
                      <option key={index} value={library.id}>
                        {library.librarieName}
                      </option>
                    ))}
                  </Field>
                </div>
                <div className="form-group">
                  <label>Genre</label>
                  <Field
                    as="select"
                    className="form-control"
                    id="genre"
                    name="genre"
                  >
                    <option value="" disabled>
                      Select Genre
                    </option>
                    {Object.entries(Genre).map(([key, value]) => (
                      <option key={key} value={value}>
                        {value}
                      </option>
                    ))}
                  </Field>
                </div>
                <div className="form-group">
                  <label>isOpen</label>
                  <Field
                    type="checkbox"
                    id="isOpen"
                    name="isOpen"
                    className="updateJoinCheckbox"
                  />
                </div>
                <button type="submit">Update Club</button>
              </Form>
            </Formik>
          </Modal>
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
                    <strong>Library:</strong>{" "}
                    {libraries.find(
                      (library) => library.id === bookclub.librariesId
                    )?.librarieName || "N/A"}
                  </p>
                  <p className="card-text">
                    <strong>Genre:</strong> {bookclub.genre}
                  </p>
                  <p className="card-text">
                    <strong>Role:</strong>{" "}
                    {bookclub.role ? bookclub.role.name : "N/A"}
                  </p>
                  <button
                    className="btn btn-primary"
                    style={{
                      display:
                        bookclub.role && bookclub.role.name === "Owner"
                          ? "block"
                          : "none",
                    }}
                    onClick={() => {
                      setCurrentClub(bookclub);
                      setIsUpdateModalOpen(true);
                    }}
                  >
                    Update
                  </button>
                  <button
                    className="btn btn-danger"
                    style={{
                      display:
                        bookclub.role && bookclub.role.name === "Owner"
                          ? "block"
                          : "none",
                    }}
                    onClick={() => deleteBookClub(bookclub.id)}
                  >
                    Delete
                  </button>{" "}
                  <button
                    className="btn btn-warning"
                    style={{
                      display:
                        bookclub.role && bookclub.role.name === "Member"
                          ? "block"
                          : "none",
                    }}
                    onClick={() => leaveClub(bookclub)}
                  >
                    Leave Club
                  </button>
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
          <p>No book clubs found</p>
        </div>
      )}
    </div>
  );
};

export default MyBookClubs;
