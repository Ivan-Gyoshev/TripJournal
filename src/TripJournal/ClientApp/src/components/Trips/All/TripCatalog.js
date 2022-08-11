import { useState, useEffect } from "react";
import * as tripService from "../../../services/tripService";
import { TripCard } from "../TripCard/TripCard";
import "./TripCatalog.css";

export const TripCatalog = () => {
  const [trips, setTrips] = useState([]);

  useEffect(() => {
    tripService
      .getAllTrips()
      .then((result) => {
        console.log(result);
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
                    ? trips.map(x => <TripCard key={x._id} trip={x} />)
                    : <h3 className="no-trips">No trips yet</h3>
            }
        </div>
    </section>
  )
};
