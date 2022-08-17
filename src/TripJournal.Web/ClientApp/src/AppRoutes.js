import ApiAuthorzationRoutes from "./components/api-authorization/ApiAuthorizationRoutes";
import { Home } from "./components/Home/Home";
import { CreateTrip } from "./components/Trips/CreateTrip/CreateTrip";
import { TripCatalog } from "./components/Trips/All/TripCatalog";
import { TripDetails } from "./components/Trips/TripDetails/TripDetails";
import { EditTrip } from "./components/Trips/EditTrip/EditTrip";
import { UserTrips } from "./components/Trips/UserTrips/UserTrips";

const AppRoutes = [
  {
    index: true,
    element: <Home />,
  },
  {
    path: "/add",
    requireAuth: true,
    element: <CreateTrip />,
  },
  {
    path: "/all-trips",
    requireAuth: false,
    element: <TripCatalog />,
  },
  {
    path: "/user-trips",
    requireAuth: false,
    element: <UserTrips />,
  },
  {
    path: "/trip-details",
    requireAuth: false,
    element: <TripDetails />
  },
  {
    path: "/trip-edit",
    requireAuth: true,
    element: <EditTrip />
  },
  ...ApiAuthorzationRoutes,
];

export default AppRoutes;
