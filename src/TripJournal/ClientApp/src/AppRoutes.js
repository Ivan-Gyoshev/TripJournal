import ApiAuthorzationRoutes from "./components/api-authorization/ApiAuthorizationRoutes";
import { Home } from "./components/Home/Home";
import { CreateTrip } from "./components/Trips/CreateTrip/CreateTrip";
import { TripCatalog } from "./components/Trips/All/TripCatalog";
import { TripDetails } from "./components/Trips/TripDetails/TripDetails";

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
    path: "/trip-details",
    requireAuth: true,
    element: <TripDetails />
  },
  ...ApiAuthorzationRoutes,
];

export default AppRoutes;
