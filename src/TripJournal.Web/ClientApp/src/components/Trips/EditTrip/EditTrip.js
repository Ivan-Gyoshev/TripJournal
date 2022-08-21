import * as React from "react";
import { useState, useEffect } from "react";
import { Alert } from 'reactstrap';
import { useSearchParams, useNavigate } from "react-router-dom";
import * as tripService from "../../../services/tripService";
import "./EditTrip.css";

export const EditTrip = () => {
  const navigate = useNavigate();
  const [searchParams] = useSearchParams();
  const [trip, setTrip] = useState([]);
  const [errors, setErrors] = useState({title: "", description: "", location: "", imageUrl: ""})

  const id = searchParams.get("id");

  useEffect(() => {
    tripService
      .getTripDetails(id)
      .then((result) => {
        setTrip(result);
      })
      .catch((err) => {
        console.log(err);
      });
  }, []);

  const onSubmit = (e) => {
    e.preventDefault();
    const tripData = Object.fromEntries(new FormData(e.target));
      // In case of wrong input, we should not make API call.
      if(canSend(tripData)){        
        tripData.tripId = id;
        tripService.editTrip(tripData)
        .then(() => {
          navigate(`/trip-details?id=${id}`);
      });
    }
  };

  const canSend = (tripData) =>{
    let resultFromValidations = true;
    let resultFromFormData = true;

    console.log(tripData);
    Object.entries(errors).forEach(x => {
      if(x[1] !== ""){
        resultFromValidations = false;
        return resultFromValidations;
      }
    })

    Object.entries(tripData).forEach(x => {
      if(x[1] === ""){
        resultFromFormData = false;
        return resultFromFormData;
      }
    })

    return resultFromValidations && resultFromFormData;
  }


   // Returns wether all the requirements for creating a trip are met.
const titleChangeHandler = (e) =>{
    let currentTitle = e.target.value;
    if(currentTitle.length < 3){
        setErrors(state => ({...state, title: 'Trip title should be at least 3 characters!'}))
      } else if (currentTitle.length > 30) {
        setErrors(state => ({...state, title: 'Trip title should be up to 30 characters long!'}))
    } else {
        setErrors(state => ({...state, title: ""}))
    }
}

const locationChangeHandler = (e) =>{
  let currentLocation = e.target.value;
  if(currentLocation.length < 3){
      setErrors(state => ({...state, location: 'Trip location should be at least 3 characters!'}))
  } else if (currentLocation.length > 30) {
      setErrors(state => ({...state, location: 'Trip location should be up to 30 characters long!'}))
  } else {
      setErrors(state => ({...state, location: ""}))
  }
}

const descriptionChangeHandler = (e) =>{
  let currentDescription = e.target.value;
  if(currentDescription.length < 10){
      setErrors(state => ({...state, description: 'Trip description should be at least 10 characters!'}))
  } else if (currentDescription.length > 500) {
      setErrors(state => ({...state, description: 'Trip description should be up to 500 characters long!'}))
  } else {
      setErrors(state => ({...state, description: ""}))
  }
}

const imageUrlChangeHandler = (e) =>{
  let currentImageUrl = e.target.value;
  if(currentImageUrl.length < 1){
      setErrors(state => ({...state, imageUrl: 'Trip Image Url is required'}))
  } else {
      setErrors(state => ({...state, imageUrl: ""}))
  }
}

  return (
    <section id="edit-page" className="edit-page">
      <form id="create" onSubmit={onSubmit}>
        <fieldset>
          <legend>
            <span className="dot"></span>Edit Trip
          </legend>
          <label htmlFor="title">Title:</label>
          <input
            type="text"
            id="title"
            name="title"
            defaultValue={trip.title}
            onChange={titleChangeHandler}
          />
           { errors.title &&
             <Alert color="danger" show={errors.title}>{errors.title}</Alert>}
          <label htmlFor="location">Location:</label>
          <input
            type="text"
            id="location"
            name="location"
            defaultValue={trip.location}
            onChange={locationChangeHandler}
          />
           { errors.location &&
             <Alert color="danger" show={errors.location}>{errors.location}</Alert>}
          <label htmlFor="imageUrl">Image URL:</label>
          <input
            type="text"
            id="imageUrl"
            name="imageUrl"
            defaultValue={trip.imageUrl}
            onChange={imageUrlChangeHandler}
          />
           { errors.imageUrl &&
             <Alert color="danger" show={errors.imageUrl}>{errors.imageUrl}</Alert>}
          <label htmlFor="description">Description:</label>
          <textarea
            name="description"
            id="description"
            defaultValue={trip.description}
            onChange={descriptionChangeHandler}
          />
           { errors.description &&
             <Alert color="danger" show={errors.description}>{errors.description}</Alert>}
          <label htmlFor="type">Type:</label>
          <select id="type" name="type">
            <option value="seaside">Seaside</option>
            <option value="mountainside">Mountainside</option>
            <option value="cities">Cities</option>
            <option value="historical">Historical</option>
            <option value="islands">Islands</option>
          </select>
        </fieldset>
        <input className="btn submit" type="submit" value="Edit Trip" />
      </form>
    </section>
  );
};
