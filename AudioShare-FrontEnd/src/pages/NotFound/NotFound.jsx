import { Link } from "react-router-dom"
import { Box } from "@mui/material";

export default function NotFound() {
    return (
        <Box component="section" display="inline-block" align="center" sx={{
            backgroundColor: "black",
            width: 300,
            border: 2,
            m: 3,
            minWidth: 400,
            borderRadius: 4,
            borderColor: "#8d46ff",
        }}>
            <Box component="h2">Error 404</Box>
            <Box component="p">The page cannot be found.</Box>
            <Box sx={{ m: 2 }}>
                <Link to="/">Back to the homepage...</Link>
            </Box>
        </Box>
    )
}
