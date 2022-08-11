import ApiAuthorzationRoutes from "./components/api-authorization/ApiAuthorizationRoutes";
import { Home } from "./components/Home";
import { CreateTrip } from "./components/Trips/CreateTrip/CreateTrip";
import { TripCatalog } from "./components/Trips/All/TripCatalog";

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
  ...ApiAuthorzationRoutes,
];

export default AppRoutes;
