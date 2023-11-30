import React from "react";
import { useAuth0, withAuthenticationRequired } from "@auth0/auth0-react";
import Loading from "../../../Loading";
import IMAGES from "../../../../Images/Images";
import Button from "react-bootstrap/Button";

//To create a new page create a new tsx file, and link it in both App.tsx, and SidebarContent.tsx
// function Test(): JSX.Element {
//   return <div className="example">this an example</div>;
// }

function HomePage() {
  const { isAuthenticated, loginWithRedirect } = useAuth0();
  return (
    <>
      <div className="text-center" style={{ paddingTop: "300px" }}>
        <img src={IMAGES.image1} alt="image"></img>
      </div>
      {!isAuthenticated && (
        <div className="text-center" style={{ paddingTop: "20px" }}>
          <Button
            className="btn-lg"
            onClick={() => {
              loginWithRedirect();
            }}
            variant="outline-light"
            type="submit"
          >
            Login
          </Button>
        </div>
      )}
    </>
  );
}
export default HomePage;
