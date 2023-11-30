import { useState } from "react";
import { useAuth0, withAuthenticationRequired } from "@auth0/auth0-react";
import Loading from "../../../Loading";

function ListGroup() {
  let items = ["Kaatsheuvel", "Tilburg", "Waalwijk", "Eindhoven"];
  const [selectedIndex, setSelectedIndex] = useState(-1);
  const { user } = useAuth0();
  console.log(user);
  return (
    <>
      <h1>List</h1>
      {items.length === 0 && <p>No item found</p>}
      <ul className="list-group">
        {items.map((item, index) => (
          <li
            className={
              selectedIndex === index
                ? "list-group-item active"
                : "list-group-item"
            }
            key={item}
            onClick={() => {
              setSelectedIndex(index);
            }}
          >
            {item}
          </li>
        ))}
      </ul>
    </>
  );
}

export default withAuthenticationRequired(ListGroup, {
  onRedirecting: () => <Loading></Loading>,
});
