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
    <>      
    <div className="heading-usertrips">
      <h1 className="heading">
        <strong>My trips</strong>The destinations you love.
      </h1>
    </div>
    <section id="catalog">
        <div className="trips-catalog">
            { userTrips.length > 0
                    ? userTrips.map(x => <TripCard key={x.id} trip={x} />)
                    : <h3 className="no-trips-user">You have not post any trips yet.</h3>
            }
        </div>
    </section>
    </>
  )
};
