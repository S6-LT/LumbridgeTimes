import ListGroup from "./components/Content/Pages/ListGroup/ListGroup";
import Test from "./components/Content/Pages/Test/Test";
import HomePage from "./components/Content/Pages/HomePage/HomePage";
import Profile from "./components/Content/Pages/Profile/Profile";
import NavBar from "./components/NavBar/NavBar";
import Content from "./components/Content/Content";
import Message from "./components/Content/Pages/Messages/Message";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { useAuth0 } from "@auth0/auth0-react";

function App(): JSX.Element {
  const { isLoading, error, isAuthenticated } = useAuth0();

  if (error) {
    return <div>Oops... {error.message}</div>;
  }
  return (
    <div className="App">
      <BrowserRouter>
        <div className="nav">
          <NavBar></NavBar>
        </div>
        <div className="content">
          <Content>
            <Routes>
              <Route path="/" element={<HomePage />} />
              <Route path="/Profile" element={<Profile />} />
              <Route path="/List" element={<ListGroup />} />
              <Route path="/Message" element={<Message />} />
              <Route path="/Test" element={<Test />} />
            </Routes>
          </Content>
        </div>
      </BrowserRouter>
    </div>
  );
}

export default App;
