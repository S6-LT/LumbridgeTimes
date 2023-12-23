import React from "react";
import { useAuth0, withAuthenticationRequired } from "@auth0/auth0-react";
import Loading from "../../../Loading";

//To create a new page create a new tsx file, and link it in both App.tsx, and SidebarContent.tsx
// function Test(): JSX.Element {
//   return <div className="example">this an example</div>;
// }



function Test() {
  const { user } = useAuth0();
  console.log(user);
  return (
    <>
      <div className="example">this an example</div>
    </>
  );
}
export default withAuthenticationRequired(Test, {
  onRedirecting: () => <Loading></Loading>,
});
