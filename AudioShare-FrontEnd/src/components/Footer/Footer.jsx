import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Container from '@mui/material/Container';
import FacebookIcon from '@mui/icons-material/Facebook';
import RedditIcon from '@mui/icons-material/Reddit';
import InstagramIcon from '@mui/icons-material/Instagram';
import LinkedInIcon from '@mui/icons-material/LinkedIn';

export default function Footer() {
    return (
        <Box component="footer" sx={{ backgroundColor: "#8d46ff" }}>
            <Container maxWidth="xl">
                <Toolbar disableGutters>
                    <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' }, color: "white" }}>
                        &copy;Audio Share
                    </Box>
                    <FacebookIcon sx={{ color: "white", mx: 1 }} />
                    <InstagramIcon sx={{ color: "white", mx: 1 }} />
                    <LinkedInIcon sx={{ color: "white", mx: 1 }} />
                    <RedditIcon sx={{ color: "white", mx: 1 }} />
                </Toolbar>
            </Container>
        </Box>
    );
};
