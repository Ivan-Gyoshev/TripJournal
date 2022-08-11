import "./TripCard.css";

export const TripCard = ({ trip }) => {


  return (
    <section class="card">
      <img src={trip.imageUrl} alt="img" />
      <h1>{trip.title}</h1>
      <p>{trip.location}</p>
      <p>{trip.description}</p>
      <p>{trip.type}</p>
    </section>
  );
};
