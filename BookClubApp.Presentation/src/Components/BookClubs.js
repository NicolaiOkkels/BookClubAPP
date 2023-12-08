import React, { useEffect, useState } from "react";
import axios from "axios";
import Modal from 'react-modal';
import { Region } from '../Enums/Region';
import { ClubType } from '../Enums/ClubType';
import { Genre } from '../Enums/Genre';
import { Formik, Field, Form } from 'formik';

const App = () => {
  const [bookclubs, setBookclubs] = useState([]);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [isUpdateModalOpen, setIsUpdateModalOpen] = useState(false);
  const [currentClub, setCurrentClub] = useState({});

  useEffect(() => {
    (async () => await ListClubs())();
    Modal.setAppElement('#root');
  }, []);

  async function ListClubs() {
    const result = await axios.get("http://localhost:5179/BookClub/getclubs");
    setBookclubs(result.data);
    //console.log(result.data);
  }

  async function CreateClub(values) {
    try {
      values.isOpen = true;
      const response = await axios.post("http://localhost:5179/BookClub/createclub", values);
      //console.log(response.data);

      alert("Club Created successfully");
      ListClubs();
      setIsModalOpen(false);
    } catch (error) {
      alert("Error creating club");
    }
  }
  async function UpdateClub(id, values) {
    try {
      const response = await axios.put(`http://localhost:5179/BookClub/updateclub/${id}`, values);

      alert("Club updated successfully");
      ListClubs();
      setIsUpdateModalOpen(false);
    } catch (error) {
      alert("Error updating club");
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
        <Formik
          initialValues={{ name: '', description: '', type: '', region: '', genre: '', isOpen: true }}
          onSubmit={CreateClub}
        >
          <Form>
            <div className="form-group">
              <label>BookClub Name</label>
              <Field type="text" className="form-control" id="name" name="name" />
            </div>
            <div className="form-group">
              <label>BookClub Description</label>
              <Field type="text" className="form-control" id="description" name="description" />
            </div>
            <div className="form-group">
              <label>BookClub Type</label>
              <Field as="select" className="form-control" id="type" name="type">
                <option value="" disabled>Select Club type</option>
                {Object.entries(ClubType).map(([key, value]) => (
                  <option key={key} value={value}>
                    {value}
                  </option>
                ))}
              </Field>
            </div>
            <div className="form-group">
              <label>BookClub Region</label>
              <Field as="select" className="form-control" id="region" name="region">
                <option value="" disabled>Select Region</option>
                {Object.entries(Region).map(([key, value]) => (
                  <option key={key} value={value}>
                    {value}
                  </option>
                ))}
              </Field>
            </div>
            <div className="form-group">
              <label>Genre</label>
              <Field as="select" className="form-control" id="genre" name="genre">
                <option value="" disabled>Select Genre</option>
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
        </Formik>
        <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
          <h1>BookClubs</h1>
          <button className="btn btn-primary" onClick={() => setIsUpdateModalOpen(true)}>Update Club</button>
        </div>
      </Modal>
      <Modal isOpen={isUpdateModalOpen}>
        <button onClick={() => setIsUpdateModalOpen(false)}>Close</button>
        <Formik
          initialValues={{ name: currentClub.name, description: currentClub.description, type: currentClub.type, region: currentClub.region, genre: currentClub.genre, isOpen: currentClub.isOpen }}
          onSubmit={(values) => UpdateClub(currentClub.id, values)}
        >
          <Form>
            <div className="form-group">
              <label>BookClub Name</label>
              <Field type="text" className="form-control" id="name" name="name" />
            </div>
            <div className="form-group">
              <label>BookClub Description</label>
              <Field type="text" className="form-control" id="description" name="description" />
            </div>
            <div className="form-group">
              <label>BookClub Type</label>
              <Field as="select" className="form-control" id="type" name="type">
                <option value="" disabled>Select Club type</option>
                {Object.entries(ClubType).map(([key, value]) => (
                  <option key={key} value={value}>
                    {value}
                  </option>
                ))}
              </Field>
            </div>
            <div className="form-group">
              <label>BookClub Region</label>
              <Field as="select" className="form-control" id="region" name="region">
                <option value="" disabled>Select Region</option>
                {Object.entries(Region).map(([key, value]) => (
                  <option key={key} value={value}>
                    {value}
                  </option>
                ))}
              </Field>
            </div>
            <div className="form-group">
              <label>Genre</label>
              <Field as="select" className="form-control" id="genre" name="genre">
                <option value="" disabled>Select Genre</option>
                {Object.entries(Genre).map(([key, value]) => (
                  <option key={key} value={value}>
                    {value}
                  </option>
                ))}
              </Field>
            </div>
            <div className="form-group">
              <label>isOpen</label>
              <Field type="checkbox" id="isOpen" name="isOpen" className="updateJoinCheckbox" />
            </div>
            <button type="submit">Update Club</button>
          </Form>
        </Formik>
      </Modal>
      <div className="row">
        {bookclubs?.map((bookclub, index) => (
          <div className="col-sm-3 mb-3" key={index}>
            <div className="card border">
              <img src={`https://source.unsplash.com/200x300/?${bookclub.name}`} alt="Card cap" className="card-img-top" />
              <div className="card-body">
                <h5 className="card-title">{bookclub.name}</h5>
                <p className="card-text">{bookclub.description}</p>
                <p className="card-text"><strong>Type:</strong> {bookclub.type}</p>
                <p className="card-text"><strong>Region:</strong> {bookclub.region}</p>
                <p className="card-text"><strong>Genre:</strong> {bookclub.genre}</p>
                {/* <p className="card-text"><strong>isOpen:</strong> {bookclub.isOpen}</p> */}
                <button
                  className={`btn ${bookclub.isOpen ? 'btn-success' : 'btn-danger'}`}
                  disabled={!bookclub.isOpen}
                >
                  {bookclub.isOpen ? 'Join' : 'Full'}
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
        ))}
      </div>
    </div>
  );
};

export default App;