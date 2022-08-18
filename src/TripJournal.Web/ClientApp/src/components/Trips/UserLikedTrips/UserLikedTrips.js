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
    <>      
    <div className="heading-liked">
      <h1 className="heading">
        <strong>Liked Trips</strong>All destinations that you like.
      </h1>
    </div>
    <section id="catalog">
        <div className="trips-catalog">
            { trips.length > 0
                    ? trips.map(x => <TripCard key={x.id} trip={x} />)
                    : <h3 className="no-trips">No liked trips yet</h3>
            }
        </div>
    </section>
    </>
  )
};
