import React, { useEffect, useState } from "react";
import axios from "axios";
import Modal from 'react-modal';
import {Region} from '../Enums/Region';
import {ClubType} from '../Enums/ClubType';
import {Genre} from '../Enums/Genre';

//Modal.setAppElement('#root') // replace '#root' with the id of your app's root element


const App = () => {
  const [bookclubs, setBookclubs] = useState([]);
  const [id, setId] = useState(0);
  const [name, setName] = useState("");
  const [description, setDescription] = useState("");
  const [type, setType] = useState("");
  const [region, setRegion] = useState("");
  const [genre, setGenre] = useState("");
  const [isModalOpen, setIsModalOpen] = useState(false);


  useEffect(() => {
    (async () => await ListClubs())();
    Modal.setAppElement('#root');
  }, []);

  async function ListClubs() {
    const result = await axios.get("http://localhost:5179/BookClub/getclubs");
    setBookclubs(result.data);
    console.log(result.data);
  }
  async function CreateClub(event) {
    event.preventDefault();
    try {
      const response = await axios.post("http://localhost:5179/BookClub/createclub", {
        name: name,
        description: description,
        type: type,
        region: region,
        genre: genre,
      });
      //console the JSON response
      console.log(response.data);

      alert("Club Created successfully");
      setId(0);
      setName("");
      setDescription("");
      setType("");
      setRegion("");
      setGenre("");
      ListClubs();
      setIsModalOpen(false);
    } catch (error) {
      alert("Error creating club");
    }
  }
  return (
    <div className="container">
<div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
  <h1>BookClubs</h1>
  <button className="btn btn-primary" onClick={() => setIsModalOpen(true)}>Create New Club</button>
</div>
<Modal isOpen={isModalOpen}>
  <button onClick={() => setIsModalOpen(false)}>Close</button>
</Modal>
      <Modal isOpen={isModalOpen}>
        <button onClick={() => setIsModalOpen(false)}>Close</button>
      
        <form>
          <div className="form-group">
            <input
              type="text"
              className="form-control"
              id="id"
              hidden
              value={id}
              onChange={(event) => {
                setId(event.target.value);
              }}
            />
          </div>
          <div className="form-group">
            <label>BookClub Name</label>
            <input
              type="text"
              className="form-control"
              id="name"
              value={name}
              onChange={(event) => {
                setName(event.target.value);
              }}
            />
          </div>
          <div className="form-group">
            <label>BookClub Description</label>
            <input
              type="text"
              className="form-control"
              id="description"
              value={description}
              onChange={(event) => {
                setDescription(event.target.value);
              }}
            />
          </div>
          <div className="form-group">
            <label>BookClub Type</label>
            <select
              className="form-control"
              id="type"
              value={type}
              onChange={(event) => {
                setType(event.target.value);
              }}
            >
              <option value="" disabled>Select Club type</option>
              {Object.entries(ClubType).map(([key, value]) => (
                <option key={key} value={value}>
                  {value}
                </option>
              ))}
            </select>
          </div>
          <div className="form-group">
            <label>BookClub Region</label>
            <select
              className="form-control"
              id="region"
              value={region}
              onChange={(event) => {
                setRegion(event.target.value);
              }}
            >
              <option value="" disabled>Select Region</option>
              {Object.entries(Region).map(([key, value]) => (
                <option key={key} value={value}>
                  {value}
                </option>
              ))}
            </select>
          </div>
          <div className="form-group">
            <label>Genre</label>
            <select
              className="form-control"
              id="genre"
              value={genre}
              onChange={(event) => {
                setGenre(event.target.value);
              }}
            >
              <option value="" disabled>Select Genre</option>
              {Object.entries(Genre).map(([key, value]) => (
                <option key={key} value={value}>
                  {value}
                </option>
              ))}
            </select>
          </div>

          <div>
            <button className="btn btn-primary" onClick={CreateClub}>
              Create Club
            </button>
          </div>
        </form>
        </Modal>
        <div className="row">
        {bookclubs?.map((bookclub, index) => (
  <div className="col-sm-3 mb-3">
    <div className="card border">
      {/* <img src={`https://picsum.photos/200/300?random=${index}`} alt="Card cap" className="card-img-top" /> */}
      <img src={`https://source.unsplash.com/200x300/?${bookclub.name}`} alt="Card cap" className="card-img-top" />
      <div className="card-body">
        <h5 className="card-title">{bookclub.name}</h5>
        <p className="card-text">{bookclub.description}</p>
        <p className="card-text"><strong>Type:</strong> {bookclub.type}</p>
        <p className="card-text"><strong>Region:</strong> {bookclub.region}</p>
        <p className="card-text"><strong>Genre:</strong> {bookclub.genre}</p>
      </div>
    </div>
  </div>
))}
      </div>
    </div>
  );
};

export default App;
