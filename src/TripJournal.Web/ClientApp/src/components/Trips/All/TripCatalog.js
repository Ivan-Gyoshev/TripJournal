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
        setTrips(result);
      })
      .catch((err) => {
        console.log(err);
      });
  }, []);

  return (
    <>      
    <div className="heading-all">
      <h1 className="heading">
        <strong>Trips Catalog</strong>Find your destination.
      </h1>
    </div>
    <section id="catalog">
      <div className="trips-catalog">
        {trips.length > 0 
        ? trips.map((x) => <TripCard key={x.id} trip={x} />)
        : <h3 className="no-trips">No trips yet</h3>
        }
      </div>
    </section>
    </>
  );
};
