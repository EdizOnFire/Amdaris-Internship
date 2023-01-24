import { LogLevel } from "@azure/msal-browser";

export const msalConfig = {
    auth: {
        clientId: "e9d7d8bc-19bb-4de3-a010-347ba322ed42",
        // authority: "https://login.microsoftonline.com/544f8ac3-ce4c-47d1-9b72-284ac54b8d1c",
        redirectUri: "http://localhost:3000/"
    },
    cache: {
        cacheLocation: "sessionStorage", // This configures where your cache will be stored
        storeAuthStateInCookie: false, // Set this to "true" if you are having issues on IE11 or Edge
    },
    // system: {	
    //     loggerOptions: {	
    //         loggerCallback: (level, message, containsPii) => {	
    //             if (containsPii) {		
    //                 return;		
    //             }		
    //             switch (level) {		
    //                 case LogLevel.Error:		
    //                     console.error(message);		
    //                     return;		
    //                 case LogLevel.Info:		
    //                     console.info(message);		
    //                     return;		
    //                 case LogLevel.Verbose:		
    //                     console.debug(message);		
    //                     return;		
    //                 case LogLevel.Warning:		
    //                     console.warn(message);		
    //                     return;		
    //             }	
    //         }	
    //     }	
    // }
};

export const loginRequest = {
    scopes: ["api://29d606f0-7736-4ddf-9998-97dca1fd696d/access_as_user"]
};