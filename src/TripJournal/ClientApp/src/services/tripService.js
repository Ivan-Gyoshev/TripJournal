import { url } from "./apiServer";
import * as request from "./requestProvider";

export const createTrip = (tripData) =>
  request.post(`${url}/trips/create`, tripData);
