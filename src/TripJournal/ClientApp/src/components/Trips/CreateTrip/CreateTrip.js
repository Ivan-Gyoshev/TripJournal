import * as React from "react";
import * as tripService from "../../../services/tripService";
import "./CreateTrip.css";

export const CreateTrip = () => {
  const onSubmit = (e) => {
    e.preventDefault();

    const tripData = Object.fromEntries(new FormData(e.target));

    tripService.createTrip(tripData);
  };

  return (
    <section id="create-page" className="auth">
      <form id="create" onSubmit={onSubmit}>
        <fieldset>
          <legend>
            <span className="dot"></span>Add Trip
          </legend>
          <label htmlFor="title">Title:</label>
          <input
            type="text"
            id="title"
            name="title"
            placeholder="Enter title..."
          />
          <label htmlFor="location">Location:</label>
          <input
            type="text"
            id="location"
            name="location"
            placeholder="Enter location..."
          />
          <label htmlFor="imageUrl">Image:</label>
          <input
            type="text"
            id="imageUrl"
            name="imageUrl"
            placeholder="Upload a photo..."
          />
          <label htmlFor="description">Description:</label>
          <textarea name="description" id="description" defaultValue={""} />
          <label htmlFor="type">Type:</label>
          <select id="type" name="type">
            <option value="seaside">Seaside</option>
            <option value="mountainside">Mountainside</option>
            <option value="cities">Cities</option>
          </select>
        </fieldset>
        <input className="btn submit" type="submit" value="Add Trip" />
      </form>
    </section>
  );
};
