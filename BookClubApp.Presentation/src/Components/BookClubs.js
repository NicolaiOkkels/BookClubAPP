import React, { useEffect, useState, useCallback } from "react";
import Modal from "react-modal";
import { useAuth0 } from "@auth0/auth0-react";
import { Genre } from "../Enums/Genre";
import { Formik, Field, Form } from "formik";
import useAuthApi from "../hooks/useAuthApi";

const App = () => {
  const [bookclubs, setBookclubs] = useState([]);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [isUpdateModalOpen, setIsUpdateModalOpen] = useState(false);
  const [currentClub, setCurrentClub] = useState({});
  const api = useAuthApi();
  const [libraries, setLibraries] = useState([]);
  const [sortGenre, setSortGenre] = useState("");
  const [sortType, setSortType] = useState("");
  const { user, isAuthenticated } = useAuth0();

  const ClubType = {
    Online: 1,
    Local: 2,
  };

  const Genres = {
    Fiction: 1,
    Fantasy: 2,
    ScienceFiction: 3,
    Mystery: 4,
    Thriller: 5,
    Romance: 6,
    Western: 7,
    Dystopian: 8,
    Horror: 9,
    HistoricalFiction: 10,
    NonFiction: 11,
  };

  const ListClubs = useCallback(async () => {
    const queryString = new URLSearchParams({
      genre: sortGenre,
      type: sortType,
    }).toString();

    const result = await api.get(`/BookClub/bookclubs/sorted?${queryString}`);
    setBookclubs(result.data);
  }, [sortGenre, sortType, api, setBookclubs]);

  const ListLibraries = useCallback(async () => {
    const result = await api.get("/Library/getlibraries");
    setLibraries(result.data);
    console.log("list of libraries ", result.data);
  }, [api, setLibraries]); // Add any dependencies here

  useEffect(() => {
    (async () => {
      await ListClubs();
      await ListLibraries();
    })();
    Modal.setAppElement("#root");
  }, [ListClubs, ListLibraries]);

  async function CreateClub(values) {
    if (!isAuthenticated || !user) return;

    try {
      const memberIdResponse = await api.get(
        `/Member/getmemberid?email=${user?.email}`
      );
      const memberId = memberIdResponse.data;

      values = {
        ...values,
        memberId: memberId,
        isOpen: true,
        librariesId: Number(values.librariesId),
      };

      await api.post(`/BookClub/createclub`, values);

      console.log("the values being sent to server: ", values);

      alert("Club Created successfully");
      ListClubs();
      setIsModalOpen(false);
    } catch (error) {
      alert("Error creating club");
    }
  }

  async function UpdateClub(id, values) {
    try {
      await api.put(`/BookClub/updateclub/${id}`, values);
      values.librariesId = Number(values.librariesId);
      console.log("the values being sent to server: ", values);

      alert("Club updated successfully");
      ListClubs();
      setIsUpdateModalOpen(false);
    } catch (error) {
      alert("Error updating club");
    }
  }

  return (
    <div className="container">
      <div
        style={{
          display: "flex",
          justifyContent: "space-between",
          alignItems: "center",
        }}
      >
        <h1>BookClubs</h1>
        <button
          className="btn btn-primary"
          onClick={() => setIsModalOpen(true)}
        >
          Create New Club
        </button>
      </div>
      <div style={{ marginBottom: "20px" }}>
        <select
          value={sortGenre}
          onChange={(e) => setSortGenre(e.target.value)}
        >
          <option value="">Select Genre</option>
          {Object.entries(Genres).map(([key]) => (
            <option key={key} value={key}>
              {key}
            </option>
          ))}
        </select>

        <select value={sortType} onChange={(e) => setSortType(e.target.value)}>
          <option value="">Select Type</option>
          {Object.entries(ClubType).map(([key]) => (
            <option key={key} value={key}>
              {key}
            </option>
          ))}
        </select>

        <button onClick={ListClubs}>Search</button>
      </div>

      <div className="row">
        {bookclubs?.map((bookclub, index) => (
          <div className="col-sm-3 mb-3" key={index}>
            {/* Your code for displaying each bookclub */}
          </div>
        ))}
      </div>
      <Modal isOpen={isModalOpen}>
        <button onClick={() => setIsModalOpen(false)}>Close</button>
        <Formik
          initialValues={{
            name: "",
            description: "",
            type: "",
            librariesId: "",
            genre: "",
            isOpen: true,
          }}
          onSubmit={CreateClub}
        >
          {({ values }) => (
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
              {values.type !== "Online" && (
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
                    {libraries.map((library) => (
                      <option key={library.id} value={library.id}>
                        {library.librarieName}
                      </option>
                    ))}
                  </Field>
                </div>
              )}
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
              <div>
                <button type="submit" className="btn btn-primary">
                  Create Club
                </button>
              </div>
            </Form>
          )}
        </Formik>
        <div
          style={{
            display: "flex",
            justifyContent: "space-between",
            alignItems: "center",
          }}
        >
          <h1>BookClubs</h1>
        </div>
      </Modal>
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
              <Field as="select" className="form-control" id="type" name="type">
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
      <div className="row">
        {bookclubs?.map((bookclub, index) => {
          return (
            <div className="col-sm-3 mb-3" key={index}>
              <div className="card border">
                <img
                  src={`https://source.unsplash.com/200x300/?${bookclub.name}`}
                  alt="Card cap"
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
                  <button
                    className={`btn ${
                      bookclub.isOpen ? "btn-success" : "btn-danger"
                    }`}
                    disabled={!bookclub.isOpen}
                  >
                    {bookclub.isOpen ? "Join" : "Full"}
                  </button>
                  <button
                    className="btn btn-primary"
                    onClick={() => {
                      setCurrentClub(bookclub);
                      setIsUpdateModalOpen(true);
                    }}
                  >
                    Update
                  </button>
                </div>
              </div>
            </div>
          );
        })}
      </div>
    </div>
  );
};

export default App;
