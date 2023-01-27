import { PublicClientApplication } from "@azure/msal-browser";
import { MsalProvider } from "@azure/msal-react";
import { msalConfig } from "./authConfig";
import ReactDOM from "react-dom/client";
import React from "react";
import App from "./App";

const msalInstance = new PublicClientApplication(msalConfig);

ReactDOM.createRoot(document.getElementById("root")).render(
    <MsalProvider instance={msalInstance}>
        <App />
    </MsalProvider>
);
