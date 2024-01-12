import React, { useEffect, useState, useCallback } from "react";
import Modal from "react-modal";
import { useAuth0 } from "@auth0/auth0-react";
import { Genre } from "../Enums/Genre";
import { ClubType } from "../Enums/ClubType";
import { Formik, Field, Form } from "formik";
import useAuthApi from "../hooks/useAuthApi";

const App = () => {
  const [bookclubs, setBookclubs] = useState([]);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const api = useAuthApi();
  const [libraries, setLibraries] = useState([]);
  const [sortGenre, setSortGenre] = useState("");
  const [sortType, setSortType] = useState("");
  const { user, isAuthenticated } = useAuth0();
  const [isLoading, setIsLoading] = useState(false);

  const getMemberId = useCallback(async (email) => {
    const memberIdResponse = await api.get(`/Member/getmemberid?email=${email}`);
    return memberIdResponse.data;
  }, [api]);

  const ListClubs = useCallback(async () => {
    setIsLoading(true);
    const queryString = new URLSearchParams({
      genre: sortGenre,
      type: sortType,
    }).toString();
  
    const result = await api.get(`/BookClub/bookclubs/sorted?${queryString}`);
    const membershipsResult = await api.get(`/Membership/getAllMemberships`);
    const memberId = await getMemberId(user?.email);
    const myMemberships = membershipsResult.data.filter(membership => membership.memberId === memberId);
    const myMembershipClubIds = myMemberships.map(membership => membership.bookClubId);
    const filteredClubs = result.data.filter(club => !myMembershipClubIds.includes(club.id));
    
    setBookclubs(filteredClubs);
    setIsLoading(false);
  }, [sortGenre, sortType, api, getMemberId, user?.email]);

  const ListLibraries = useCallback(async () => {
    const result = await api.get("/Library/getlibraries");
    setLibraries(result.data);
  }, [api, setLibraries]); // Add any dependencies here



  useEffect(() => {
    (async () => {
      await ListClubs();
      await ListLibraries();
      await getMemberId(user?.email);
    })();
    Modal.setAppElement("#root");
  }, [ListClubs, ListLibraries, getMemberId, user?.email]);


  
  async function CreateClub(values) {
    if (!isAuthenticated || !user) return;
  
    try {
      const memberId = await getMemberId(user?.email);
      values = {
        ...values,
        memberId: memberId,
        isOpen: true,
        librariesId: Number(values.librariesId),
        book: null
      };
      console.log(values);
      await api.post(`/BookClub/createclub`, values);
  
      alert("Club Created successfully");
      ListClubs();
      setIsModalOpen(false);
    } catch (error) {
      alert("Error creating club");
    }
  }


  async function joinClub(bookclub) {
    if (!bookclub.isOpen) {
      return;
    }

    try {
      const memberIdResponse = await api.get(
        `/Member/getmemberid?email=${user?.email}`
      );
      console.log("memberIdResponse: ", memberIdResponse);
      const memberId = memberIdResponse.data;

      if (!memberId) {
        throw new Error("Member ID not found");
      }

      await api.post(`/Membership/joinclub/${bookclub.id}/${memberId}`);
      alert("Joined club successfully");
      ListClubs();
    } catch (error) {
      console.error(error);
      alert("Error joining club");
    }
  }

  return (
    <div>
      {isLoading ? (
        <div>Loading...</div> // replace this with your loading spinner component
      ) : (
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
              onClick={() => setIsModalOpen(true)}>
              Create New Club
            </button>
          </div>
          <div style={{ marginBottom: "20px" }}>
            <select
              value={sortGenre}
              onChange={(e) => setSortGenre(e.target.value)} >
              <option value="">Select Genre</option>
              {Object.entries(Genre).map(([key]) => (
                <option key={key} value={key}>
                  {key}
                </option>
              ))}
            </select>

            <select
              value={sortType}
              onChange={(e) => setSortType(e.target.value)}
            >
              <option value="">Select Type</option>
              {Object.entries(ClubType).map(([key]) => (
                <option key={key} value={key}>
                  {key}
                </option>
              ))}
            </select>

            <button onClick={ListClubs} type="submit" className="btn btn-primary">Search</button>
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

          <div className="row">
            {bookclubs?.map((bookclub, index) => {
              return (
                <div className="col-sm-3 mb-3" key={index}>
                  <div className="card border">
                    <img src={`https://source.unsplash.com/200x300/?${bookclub.name}`}
                      alt="Card cap"
                      className="card-img-top"/>
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
                      { (
                        <button 
                        className={`btn ${bookclub.isOpen ? 'btn-success' : 'btn-danger'}`} 
                        onClick={() => joinClub(bookclub)}
                        disabled={!bookclub.isOpen}>
                        {bookclub.isOpen ? 'Join' : 'Full'}
                      </button>
                      )}
                    </div>
                  </div>
                </div>
              );
            })}
          </div>
        </div>
      )}
    </div>
  );
};

export default App;
