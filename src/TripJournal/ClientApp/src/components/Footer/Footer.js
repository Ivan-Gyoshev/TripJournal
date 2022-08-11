import React, { Component } from "react";
import { Navbar } from "reactstrap";

export const Footer = () => {
  return (
    <Navbar
      className="navbar-expand-sm nav-assig navbar-toggleable-sm ng-white border-top box-shadowr"
      light
    >
      <p style={{"marginLeft": "30%"}}>
        This is ToDo application, made for my ReactJS project deffense. &copy;
        2021
      </p>
    </Navbar>
  );
};
