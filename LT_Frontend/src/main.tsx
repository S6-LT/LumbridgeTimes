import React from "react";
import * as ReactDOM from "react-dom/client";
import App from "./App";
import "bootstrap/dist/css/bootstrap.css";
import "./Styling/Styling.scss";
import { Auth0Provider } from "@auth0/auth0-react";
import { createBrowserHistory } from "history";
import { getConfig } from "./config";
const history = createBrowserHistory();

const onRedirectCallback = (appState: any) => {
  console.log(window.location.pathname);
  history.push(
    appState && appState.returnTo ? appState.returnTo : window.location.pathname
  );
};

const config = getConfig();

const providerConfig = {
  domain: config.domain,
  clientId: config.clientId,
  ...(config.audience ? { audience: config.audience } : null),
  redirectUri: window.location.origin,
  onRedirectCallback,
};

const root = ReactDOM.createRoot(
  document.getElementById("root") as HTMLElement
);

root.render(
  <Auth0Provider {...providerConfig}>
    <App />
  </Auth0Provider>
);
