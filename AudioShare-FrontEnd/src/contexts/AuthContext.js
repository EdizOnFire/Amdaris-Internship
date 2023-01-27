import { createContext } from "react";
import { useSessionStorage } from "../hooks/useSessionStorage";

export const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
    const [auth, setAuth] = useSessionStorage("user", {});

    const userLogin = (authData) => {
        setAuth(authData);
    };

    const userLogout = () => {
        setAuth({});
    };

    return (
        <AuthContext.Provider
            value={{
                user: auth,
                userLogin,
                userLogout,
                isAuthenticated: !!auth.accessToken,
            }}>
            {children}
        </AuthContext.Provider>
    );
};
