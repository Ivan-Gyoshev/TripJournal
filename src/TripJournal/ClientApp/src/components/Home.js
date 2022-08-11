import React, { Component } from "react";
import homescreen from "./home-screen.jpg";
import { Link } from 'react-router-dom';
import "./Home.css";

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div className="home-container">
        <img className="homescreen" src={homescreen} alt="homescreen" />
        <h1 className="centered">Welcome to the Trip Journal</h1>
        <h3 className="centered-sub">
          A place where you will find lots of and different adventures
        </h3>
        <Link tag={Link} className="text-white explore" to="/all">Explore</Link>
      </div>
    );
  }
}
