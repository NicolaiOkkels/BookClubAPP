import React, { useState } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import Logout from './Logout';
import Profile from './Profile';
import './NavMenu.css';

const NavMenu = () => {
  const [collapsed, setCollapsed] = useState(true);

  const toggleNavbar = () => {
    setCollapsed(!collapsed);
  };

  return (
    <header>
      <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" container light>
        <NavbarBrand tag={Link} to="/">
          <img src="/mybookclub-logo-modified.png" alt="Logo" className="logo" style={{ width: '300px', height: '150px' }} />
        </NavbarBrand>
        <NavbarToggler onClick={toggleNavbar} className="mr-2" />
        <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!collapsed} navbar>
          <ul className="navbar-nav flex-grow">
            <div className="profile">
            <NavItem>
              <Profile />
            </NavItem>
            </div>
            <NavItem>
              <NavLink tag={Link} className="text-dark" to="/">My book clubs</NavLink>
            </NavItem>
            <NavItem>
              <NavLink tag={Link} className="text-dark" to="/booksearch">Book search</NavLink>
            </NavItem>
            <NavItem>
              <NavLink tag={Link} className="text-dark" to="/favbooks">Books</NavLink>
            </NavItem>
            <NavItem>
              <NavLink tag={Link} className="text-dark" to="/bookclubs">Book clubs</NavLink>
            </NavItem>
            <div className="logout">
            <NavItem>
              <Logout />
            </NavItem>
            </div>
          </ul>
        </Collapse>
      </Navbar>
    </header>
  );
}

export default NavMenu;