import { NavLink } from "react-router-dom";
import { AppBar, Box, Toolbar, Container, Button } from '@mui/material';
import { MusicNote } from '@mui/icons-material';
import { useIsAuthenticated, useMsal } from "@azure/msal-react";
import { loginRequest } from "../../authConfig";

export default function Navbar() {
    const isAuthenticated = useIsAuthenticated();
    const { instance } = useMsal();

    const handleLogin = () => {
        instance.loginPopup(loginRequest)
            .then(response => {
                localStorage.setItem("user", JSON.stringify(response.account));
            })
            .catch(e => {
                console.log(e);
            });
    }

    const handleLogout = () => {
        localStorage.clear();
        instance.logoutPopup({
            postLogoutRedirectUri: "/",
            mainWindowRedirectUri: "/"
        })
            .then(localStorage.clear())
            .catch(e => {
                console.log(e);
            });
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
