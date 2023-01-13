import { NavLink } from "react-router-dom";
import { AppBar, Box, Toolbar, Container, Button } from '@mui/material';
import { MusicNote } from '@mui/icons-material';

export default function Navbar() {
    return (
        <AppBar position="static">
            <Container maxWidth="xl">
                <Toolbar disableGutters>
                    <MusicNote sx={{ display: { xs: 'none', md: 'flex' } }} />
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
                    <NavLink to="/upload">
                        <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' } }}>
                            <Button sx={{ my: 2, color: 'white', display: 'block' }}>
                                Upload
                            </Button>
                        </Box>
                    </NavLink>
                    <NavLink to="/login">
                        <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' } }}>
                            <Button sx={{ my: 2, color: 'white', display: 'block' }}>
                                Login
                            </Button>
                        </Box>
                    </NavLink>
                    <NavLink to="/register">
                        <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' } }}>
                            <Button sx={{ my: 2, color: 'white', display: 'block' }}>
                                Register
                            </Button>
                        </Box>
                    </NavLink>
                    <NavLink to="/">
                        <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' } }}>
                            <Button sx={{ my: 2, color: 'white', display: 'block' }}>
                                Logout
                            </Button>
                        </Box>
                    </NavLink>
                </Toolbar>
            </Container>
        </AppBar>
    )
}
