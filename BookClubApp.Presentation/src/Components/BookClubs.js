import React, { useEffect, useState } from "react";
import axios from "axios";
import Modal from 'react-modal';

//Modal.setAppElement('#root') // replace '#root' with the id of your app's root element


const App = () => {
  const [bookclubs, setBookclubs] = useState([]);
  const [id, setId] = useState(0);
  const [name, setName] = useState("");
  const [description, setDescription] = useState("");
  const [type, setType] = useState("");
  const [region, setRegion] = useState("");
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
      await axios.post("http://localhost:5179/BookClub/createclub", {
        name: name,
        description: description,
        type: type,
        region: region,
        
      });
      alert("Club Created successfully");
      setId(0);
      setName("");
      setDescription("");
      setType("");
      setRegion("");
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
            <input
              type="text"
              className="form-control"
              id="type"
              value={type}
              onChange={(event) => {
                setType(event.target.value);
              }}
            />
          </div>
          <div className="form-group">
            <label>BookClub Region</label>
            <input
              type="text"
              className="form-control"
              id="region"
              value={region}
              onChange={(event) => {
                setRegion(event.target.value);
              }}
            />
          </div>

          <div>
            <button className="btn btn-primary" onClick={CreateClub}>
              Create Club
            </button>
          </div>
        </form>
        </Modal>
      <div className="row">
        <div className="col-12">
          <table className="table table-bordered table-striped">
            <thead>
              <tr>
                <th>Id</th>
                <th>Name</th>
                <th>Description</th>
                <th>Type</th>
                <th>Region</th>
              </tr>
            </thead>
            {bookclubs?.map(function fn(bookclub) {
              return (
                <tbody>
                  <tr>
                    <th scope="row">{bookclub.id}</th>
                    <td>{bookclub.name}</td>
                    <td>{bookclub.description}</td>
                    <td>{bookclub.type}</td>
                    <td>{bookclub.region}</td>
                  </tr>
                </tbody>
              );
            })}
          </table>
        </div>
      </div>
    </div>
  );
};

export default App;
