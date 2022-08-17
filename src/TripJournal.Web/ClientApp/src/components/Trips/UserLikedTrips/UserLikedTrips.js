import { useState, useEffect } from "react";
import * as tripService from "../../../services/tripService";
import { TripCard } from "../TripCard/TripCard";
import "./UserLikedTrips.css";

export const UserLikedTrips = () => {
  const [trips, setTrips] = useState([]);

  useEffect(() => {
    tripService
      .getTripsLikedByUser()
      .then((result) => {
        setTrips(result);
      })
      .catch((err) => {
        console.log(err);
      });
  }, []);

  return (
    <section id="catalog">
        <h1 className="trips-catalog-heading">Trips</h1>
        <div className="trips-catalog">
            { trips.length > 0
                    ? trips.map(x => <TripCard key={x.id} trip={x} />)
                    : <h3 className="no-trips">No liked trips yet</h3>
            }
        </div>
    </section>
  )
};
