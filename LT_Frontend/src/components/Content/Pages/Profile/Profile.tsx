import { useAuth0, withAuthenticationRequired } from "@auth0/auth0-react";
import Loading from "../../../Loading";

export const Profile = () => {
  const { user } = useAuth0();
  console.log(user);
  const userRole = {
    role: user?.["http://localhost:5173/Role"]
  }
  return (
    <>
      <div className="profile-picture">
        <img src={user?.picture}></img>
      </div>
      <ul className="list-group">
        <li className="list-group-item list-group-item-dark">
          Username: {user?.name}
        </li>
        <li className="list-group-item list-group-item-dark">
          Nickname: {user?.nickname}
        </li>
        <li className="list-group-item list-group-item-dark">
          Email: {user?.email}
        </li>
        {/* This shows authorization, need to have a role to see certain parts */}
        {userRole.role == "admin"  &&
        <li className="list-group-item list-group-item-dark">
          Role: {user?.["http://localhost:5173/Role"]}
        </li>
        } 
      </ul>

    </>
  );
};

export default withAuthenticationRequired(Profile, {
  onRedirecting: () => <Loading></Loading>,
});
