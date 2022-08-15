import { useState, useEffect } from "react";
import * as tripService from "../../../services/tripService";
import { TripCard } from "../TripCard/TripCard";
import "./UserTrips.css";

export const UserTrips = () => {
  const [userTrips, setUserTrips] = useState([]);

  useEffect(() => {
    tripService
      .getAllTripsForUser()
      .then((result) => {
        setUserTrips(result);
      })
      .catch((err) => {
        console.log(err);
      });
  }, []);

  return (
    <section id="catalog">
        <h1 className="trips-catalog-heading">Your Trips</h1>
        <div className="trips-catalog">
            { userTrips.length > 0
                    ? userTrips.map(x => <TripCard key={x.id} trip={x} />)
                    : <h3 className="no-trips">You have not post any trips yet.</h3>
            }
        </div>
    </section>
  )
};
