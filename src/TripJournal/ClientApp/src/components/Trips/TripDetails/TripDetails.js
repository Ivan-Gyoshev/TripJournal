import { useState, useEffect, useContext } from "react";
import { useSearchParams, Link, useNavigate } from "react-router-dom";
import * as tripService from "../../../services/tripService";
import authService from "../../../components/api-authorization/AuthorizeService";
import "./TripDetails.css";

export const TripDetails = () => {
  const navigate = useNavigate();
  const [searchParams] = useSearchParams();
  const [trip, setTrip] = useState([]);
  const [currentUser, setCurrentUser] = useState();
  const id = searchParams.get("id");

  const setTripData = async () => {
    const trip = await tripService.getTripDetails(id);
    setTrip(trip);
  };

  const setUserInfo = async () => {
    const user = await authService.getUser();
    setCurrentUser(user.sub);
  };

  useEffect(() => {
    setTripData();
    setUserInfo();
  }, []);

  const isCreator = currentUser === trip.creatorId;

  const tripDeleteHandler = () => {
    const confirmation = window.confirm(
      "If you continue you will delete this trip."
    );

    if (confirmation) {
      tripService.deleteTrip(id).then(() => {
        navigate("/all-trips");
      });
    }
  };

  return (
    <section className="details-container">
      <h1>{trip.title}</h1>
      <p className="subheading">Location: {trip.location}</p>
      <section className="img-container">
        <article className="img-content">
          <img src={trip.imageUrl} alt="img" />
        </article>
        <article className="content">
          <h4>Destination type: {trip.type}</h4>
          <p>{trip.description}</p>
          {isCreator && (
        <>
          <Link
            to={`/trip-edit?id=${trip.id}`}
            className="action-button primary edit"
          >
            Edit
          </Link>
          <button
            onClick={tripDeleteHandler}
            className="action-button primary delete"
          >
            Delete
          </button>
        </>
      )}
        </article>
      </section>     
      <p class="border"></p>
    </section>
  );
};
