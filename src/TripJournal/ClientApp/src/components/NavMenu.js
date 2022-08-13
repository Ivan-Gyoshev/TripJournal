import React, { Component } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { LoginMenu } from './api-authorization/LoginMenu';
import './NavMenu.css';
import authService from '../components/api-authorization/AuthorizeService';


export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }
  
  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render() {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow bg-dark" container light>
          <NavbarBrand tag={Link} to="/" className='text-white logo'>TripJournal</NavbarBrand>
          <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
          <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
            { authService.isAuthenticated()
             ?  <ul className="navbar-nav flex-grow user">
                  <NavItem className='nav-item'>
                    <NavLink tag={Link} className="text-white nav-button" to="/">Home</NavLink>
                  </NavItem>
                  <NavItem className='nav-item'>
                    <NavLink tag={Link} className="text-white nav-button" to="/all-trips">All Trips</NavLink>
                  </NavItem>
                  <NavItem className='nav-item'>
                    <NavLink tag={Link} className="text-white nav-button" to="/add">Add Trip</NavLink>
                  </NavItem>
                  <LoginMenu>
                  </LoginMenu>
                </ul>
            : <ul className="navbar-nav flex-grow guest">
                <NavItem className='nav-item'>
                   <NavLink tag={Link} className="text-white nav-button" to="/">Home</NavLink>
                </NavItem>
                <NavItem className='nav-item'>
                  <NavLink tag={Link} className="text-white nav-button" to="/all-trips">All Trips</NavLink>
                </NavItem>
                <LoginMenu>
                </LoginMenu>
              </ul>
            }
            
          </Collapse>
        </Navbar>
      </header>
    );
  }
}
