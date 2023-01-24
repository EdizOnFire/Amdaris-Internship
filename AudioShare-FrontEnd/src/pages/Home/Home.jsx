import { Box } from "@mui/material";
import { Link } from "react-router-dom";

const Home = () => {
    return (
        <Box component="section" id="welcomePage" align='center'>
            <Box component="h2">Welcome to </Box>
            <Box component="h1">Audio Share</Box>
            <Box sx={{ m: 4 }}>Login and upload your audio file to get the best feedback by our community.</Box>
            <Box><Link to="/browse">Browse</Link> our forum to assist colleagues in need of feedback.</Box>
        </Box>
    );
};

export default Home;
