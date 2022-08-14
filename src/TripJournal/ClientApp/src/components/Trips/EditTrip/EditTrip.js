import * as React from "react";
import * as tripService from "../../../services/tripService";
import { useState, useEffect } from "react";
import { useSearchParams, useNavigate } from "react-router-dom";
import "./EditTrip.css";
import authService from "../../api-authorization/AuthorizeService";

export const EditTrip = () => {
  const navigate = useNavigate();
  const [searchParams] = useSearchParams();
  const [trip, setTrip] = useState([]);

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
    tripData.tripId = id;

    tripService.editTrip(tripData).then(() => {
      navigate(`/trip-details?id=${id}`);
    });
  };

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
          />
          <label htmlFor="location">Location:</label>
          <input
            type="text"
            id="location"
            name="location"
            defaultValue={trip.location}
          />
          <label htmlFor="imageUrl">Image URL:</label>
          <input
            type="text"
            id="imageUrl"
            name="imageUrl"
            defaultValue={trip.imageUrl}
          />
          <label htmlFor="description">Description:</label>
          <textarea
            name="description"
            id="description"
            defaultValue={trip.description}
          />
          <label htmlFor="type">Type:</label>
          <select id="type" name="type">
            <option value="seaside">Seaside</option>
            <option value="mountainside">Mountainside</option>
            <option value="cities">Cities</option>
          </select>
        </fieldset>
        <input className="btn submit" type="submit" value="Edit Trip" />
      </form>
    </section>
  );
};
