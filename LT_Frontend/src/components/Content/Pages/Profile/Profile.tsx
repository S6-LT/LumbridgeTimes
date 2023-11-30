import { useAuth0, withAuthenticationRequired } from "@auth0/auth0-react";
import Loading from "../../../Loading";

export const Profile = () => {
  const { user } = useAuth0();
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
      </ul>
    </>
  );
};

export default withAuthenticationRequired(Profile, {
  onRedirecting: () => <Loading></Loading>,
});
