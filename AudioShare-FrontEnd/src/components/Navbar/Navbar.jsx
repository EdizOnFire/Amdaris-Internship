import { NavLink } from "react-router-dom";
import { AppBar, Box, Toolbar, Container, Button } from '@mui/material';
import { MusicNote } from '@mui/icons-material';
import { useIsAuthenticated, useMsal } from "@azure/msal-react";
import { loginRequest } from "../../authConfig";
import { AuthContext } from "../../contexts/AuthContext";
import { useContext } from "react";

export default function Navbar() {
    const isAuthenticated = useIsAuthenticated();
    const { instance } = useMsal();
    const { userLogin, userLogout } = useContext(AuthContext);

    const handleLogin = () => {
        try {
            instance.loginPopup(loginRequest)
                .then(response => {
                    console.log(response.account);
                    userLogin(response.account);
                })
        } catch (error) {
            return error;
        }
    }

    const handleLogout = () => {
        try {
            instance.logoutPopup({
                postLogoutRedirectUri: "/",
                mainWindowRedirectUri: "/"
            }).then(userLogout())
        } catch (error) {
            return error;
        }
    }

    return (
        <AppBar position="static">
            <Container maxWidth="xl">
                <Toolbar disableGutters>
                    <MusicNote sx={{ display: { xs: 'none', md: 'flex' }, fontSize: 35 }} />
                    <NavLink to="/">
                        <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' } }}>
                            <Button sx={{ my: 2, color: 'white', display: 'block' }}>
                                Home
                            </Button>
                        </Box>
                    </NavLink>
                    <NavLink to="/browse">
                        <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' } }}>
                            <Button sx={{ my: 2, color: 'white', display: 'block' }}>
                                Browse
                            </Button>
                        </Box>
                    </NavLink>
                    {isAuthenticated ?
                        <>
                            <NavLink to="/upload">
                                <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' } }}>
                                    <Button sx={{ my: 2, color: 'white', display: 'block' }}>
                                        Upload
                                    </Button>
                                </Box>
                            </NavLink>
                            <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' } }}>
                                <Button onClick={handleLogout} sx={{ my: 2, color: 'white', display: 'block' }}>
                                    Logout
                                </Button>
                            </Box>
                        </>
                        :
                        <>
                            <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' } }}>
                                <Button onClick={handleLogin} sx={{ my: 2, color: 'white', display: 'block' }}>
                                    Login
                                </Button>
                            </Box>
                            {/* <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' } }}>
                                <Button sx={{ my: 2, color: 'white', display: 'block' }}>
                                    Register
                                </Button>
                            </Box> */}
                        </>
                    }
                </Toolbar>
            </Container>
        </AppBar>
    )
}
