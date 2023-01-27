import { AppBar, Box, Toolbar, Container, Button } from "@mui/material";
import { useIsAuthenticated, useMsal } from "@azure/msal-react";
import { NavLink, useNavigate } from "react-router-dom";
import { loginRequest } from "../../authConfig";
import { AuthContext } from "../../contexts/AuthContext";
import { useContext } from "react";
import { MusicNote } from "@mui/icons-material";

export default function Navbar() {
    const { userLogin, userLogout } = useContext(AuthContext);
    const { instance } = useMsal();
    const isAuthenticated = useIsAuthenticated();
    const navigate = useNavigate();

    const handleLogin = () => {
        try {
            instance.loginPopup(loginRequest)
                .then((response) => userLogin(response.account));
        } catch (error) {
            return error;
        }
    };

    const handleLogout = () => {
        try {
            instance.logoutPopup()
                .then(userLogout(), navigate("/"));
        } catch (error) {
            return error;
        }
    };

    return (
        <AppBar position="static">
            <Container maxWidth="xl">
                <Toolbar disableGutters>
                    <MusicNote
                        sx={{ display: { xs: "none", md: "flex" }, fontSize: 35 }}
                    />
                    <NavLink to="/">
                        <Box sx={{ flexGrow: 1, display: { xs: "none", md: "flex" } }}>
                            <Button sx={{ my: 2, color: "white", display: "block" }}>
                                Home
                            </Button>
                        </Box>
                    </NavLink>
                    <NavLink to="/browse">
                        <Box sx={{ flexGrow: 1, display: { xs: "none", md: "flex" } }}>
                            <Button sx={{ my: 2, color: "white", display: "block" }}>
                                Browse
                            </Button>
                        </Box>
                    </NavLink>
                    {isAuthenticated ? (
                        <>
                            <NavLink to="/profile">
                                <Box sx={{ flexGrow: 1, display: { xs: "none", md: "flex" } }}>
                                    <Button sx={{ my: 2, color: "white", display: "block" }}>
                                        Profile
                                    </Button>
                                </Box>
                            </NavLink>
                            <NavLink to="/upload">
                                <Box sx={{ flexGrow: 1, display: { xs: "none", md: "flex" } }}>
                                    <Button sx={{ my: 2, color: "white", display: "block" }}>
                                        Upload
                                    </Button>
                                </Box>
                            </NavLink>
                            <Box sx={{ flexGrow: 1, display: { xs: "none", md: "flex" } }}>
                                <Button
                                    onClick={handleLogout}
                                    sx={{ my: 2, color: "white", display: "block" }}
                                >
                                    Logout
                                </Button>
                            </Box>
                        </>
                    ) : (
                        <Box sx={{ flexGrow: 1, display: { xs: "none", md: "flex" } }}>
                            <Button
                                onClick={handleLogin}
                                sx={{ my: 2, color: "white", display: "block" }}
                            >
                                Login
                            </Button>
                        </Box>
                    )}
                </Toolbar>
            </Container>
        </AppBar>
    );
}
