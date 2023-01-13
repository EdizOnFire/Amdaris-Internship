import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Container from '@mui/material/Container';
import Button from '@mui/material/Button';

const Footer = () => {
    return (
        <footer>
            <Container maxWidth="xl">
                <Toolbar disableGutters>
                    <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' } }}>
                        <Button sx={{ my: 2, color: 'white', display: 'block' }}>
                            &copy;AudioEditor
                        </Button>
                    </Box>
                </Toolbar>
            </Container>
        </footer>
    );
};

export default Footer;
