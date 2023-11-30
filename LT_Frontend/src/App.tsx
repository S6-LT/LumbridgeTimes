import ListGroup from "./components/Content/Pages/ListGroup/ListGroup";
import Test from "./components/Content/Pages/Test/Test";
import NavBar from "./components/NavBar/NavBar";
import Content from "./components/Content/Content";
import { BrowserRouter, Routes, Route } from "react-router-dom";

function App(): JSX.Element {
  return (
    <div className="App">
      <BrowserRouter>
        <div className="nav">
          <NavBar></NavBar>
        </div>
        <div className="content">
          <Content>
            <Routes>
              <Route path="/" element={<ListGroup />} />
              <Route path="/Test" element={<Test />} />
            </Routes>
          </Content>
        </div>
      </BrowserRouter>
    </div>
  );
}

export default App;
