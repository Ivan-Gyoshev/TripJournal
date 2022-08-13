import "./TripCard.css";
import { Link } from "react-router-dom";

export const TripCard = ({ trip }) => {
  return (
    <section className="card">
      <div className="img-box">
        <img src={trip.imageUrl} alt="img" />
      </div>
      <div className="title">
      <h1>{trip.title}</h1>
      </div>
      <div className="details">
        <Link to={`/trip-details?id=${trip.id}`} className="details-button">
          Details
        </Link>
      </div>
    </section>
  );
};
