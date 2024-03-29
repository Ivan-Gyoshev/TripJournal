import { url } from "./apiServer";
import * as request from "./requestProvider";

export const createTrip = (tripData) =>
  request.post(`${url}/trips/create`, tripData);

export const editTrip = (tripData) =>
  request.post(`${url}/trips/edit`, tripData);

export const deleteTrip = (id) => request.post(`${url}/trips/delete?id=${id}`);

export const getAllTrips = () => request.get(`${url}/trips/all`);

export const getAllTripsForUser = () => request.get(`${url}/trips/userTrips`);

export const getTripDetails = (id) =>
  request.get(`${url}/trips/details?id=${id}`);

export const likeTrip = (id) => request.post(`${url}/trips/like`, id);

export const unlikeTrip = (id) => request.post(`${url}/trips/unlike`, id);

export const getHasUserLikedTrip = (id) => request.get(`${url}/trips/likeForUser?tripId=${id}`);

export const getTripLikesCount = (id) =>  request.get(`${url}/trips/tripLikes?tripId=${id}`);

export const getTripsLikedByUser = () => request.get(`${url}/trips/userLikedTrips`)