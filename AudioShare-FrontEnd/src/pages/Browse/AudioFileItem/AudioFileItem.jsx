import { Box, Button } from '@mui/material';
import { Link } from "react-router-dom";

export default function AudioFileItem({ item }) {
    return (
        <Box component="article" className="audioFile">
            <Box component="h1" sx={{ color: "white" }} className="itemTitle">{item.title}</Box>
            <Button>
                <Link to={`/browse/${item.id}`}> Details</Link>
            </Button>
        </Box>
    );
};
