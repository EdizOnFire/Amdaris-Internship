import { Box } from "@mui/material";
import { Link } from "react-router-dom"

const NotFound = () => {
    return (
        <Box component="section" display="inline-block" align="center" sx={{
            backgroundColor: "black",
            width: 300,
            border: 2,
            m: 3,
            minWidth: 400,
            borderRadius: 4,
            borderColor: "#4c00c5",
        }}>
            <Box component="h2">Error 404</Box>
            <Box component="p">The page cannot be found.</Box>
            <Box sx={{ m: 2 }}>
                <Link to="/">Back to the homepage...</Link>
            </Box>
        </Box>
    )
};

export default NotFound;