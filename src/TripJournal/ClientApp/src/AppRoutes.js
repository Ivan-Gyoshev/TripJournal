import ApiAuthorzationRoutes from "./components/api-authorization/ApiAuthorizationRoutes";
import { Home } from "./components/Home/Home";
import { CreateTrip } from "./components/Trips/CreateTrip/CreateTrip";
import { TripCatalog } from "./components/Trips/All/TripCatalog";
import { TripDetails } from "./components/Trips/TripDetails/TripDetails";
import { EditTrip } from "./components/Trips/EditTrip/EditTrip";

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
  {
    path: "/trip-edit",
    requireAuth: true,
    element: <EditTrip />
  },
  ...ApiAuthorzationRoutes,
];

export default AppRoutes;
