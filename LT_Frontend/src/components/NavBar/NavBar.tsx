import Button from "react-bootstrap/Button";
import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import { useAuth0 } from "@auth0/auth0-react";

function NavBar() {
  const { isAuthenticated, loginWithRedirect, logout, user } = useAuth0();
  console.log(user)
  
  
  const userRole = {
    role: user?.["http://localhost:5173/Role"]
  }


  return (
    <Navbar
      bg="dark"
      data-bs-theme="dark"
      expand="sm"
      className="bg-body-tertiary"
      fixed="top"
    >
      <Container fluid>
        <Navbar.Brand href="/">LumbridgeTimes</Navbar.Brand>
        <Navbar.Toggle aria-controls="navbarScroll" />
        <Navbar.Collapse id="navbarScroll">
          <Nav
            className="me-auto my-2 my-lg-0"
            style={{ maxHeight: "100px" }}
            navbarScroll
          >
            {isAuthenticated && (
              <Button
                onClick={() => {
                  logout();
                }}
                variant="outline-light"
                type="submit"
              >
                Logout
              </Button>
            )}
            {isAuthenticated && <Nav.Link href="/profile">Profile</Nav.Link>}
            {isAuthenticated && <Nav.Link href="/list">List</Nav.Link>}
            {isAuthenticated && <Nav.Link href="/Message">Message</Nav.Link>}
            {isAuthenticated && <Nav.Link href="/test">Test</Nav.Link>}
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}

export default NavBar;
