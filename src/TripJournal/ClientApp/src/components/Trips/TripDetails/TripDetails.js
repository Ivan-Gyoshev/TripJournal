import { useState, useEffect } from "react";
import { useSearchParams, Link, useNavigate } from "react-router-dom";
import * as tripService from "../../../services/tripService";
import authService from "../../../components/api-authorization/AuthorizeService";
import "./TripDetails.css";

export const TripDetails = () => {
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

  const gameDeleteHandler = () =>{
    const confirmation = window.confirm('If you continue you will delete this trip.');

    if(confirmation) {
        tripService.deleteTrip(id)
        .then(() => {
            navigate('/all-trips')
        })
    }
  }

  return (
    <section className="details-container">
      <h1>{trip.title}</h1>
      <p class="subheading">Location: {trip.location}</p>
      <section className="img-container">
        <article class="img-content">
          <img src={trip.imageUrl} alt="img" />
        </article>
        <article class="content">
          <h4>Destination type: {trip.type}</h4>
          <p>{trip.description}</p>
        </article>
      </section>
      <Link to={`/trips/edit?id=${trip.id}`} class="action-button primary edit">Edit</Link >
      <button onClick={gameDeleteHandler} class="action-button primary delete">Delete</button>
      <p class="border"></p>
    </section>
  );
};
