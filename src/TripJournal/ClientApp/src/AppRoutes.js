import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { CreateTrip } from "./components/Trips/CreateTrip/CreateTrip";
import { Home } from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },  
  {
    path: '/add',
    requireAuth: true,
    element: <CreateTrip />
  },
  ...ApiAuthorzationRoutes
];

export default AppRoutes;
