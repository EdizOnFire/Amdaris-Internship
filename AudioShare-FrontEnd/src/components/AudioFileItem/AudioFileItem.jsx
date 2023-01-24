import { useEffect, useState } from "react";
import { Box, Button } from "@mui/material";
import { Link } from "react-router-dom";
import * as itemService from "../../services/itemService";

export default function AudioFileItem({ item }) {
    const [loadingState, setLoadingState] = useState("Retrieving...");
    const [downloadLink, setDownloadLink] = useState("");

    useEffect(() => {
        if (item) {
            itemService
                .download(item.path)
                .then((response) => {
                    const url = URL.createObjectURL(response);
                    setDownloadLink(url);
                    setLoadingState("Loaded");
                })
                .catch((error) => {
                    setLoadingState("Failed");
                    return error;
                });
        }
    }, [item]);

    return (
        <Box component="article" display="inline-block" sx={{
            backgroundColor: "black",
            width: 300,
            color: "#4c00c5",
            border: 2,
            m: 3,
            minWidth: 400,
            borderRadius: 4
        }}>
            <Box sx={{ color: "white", my: 1 }}>
                <Box component="small" >By: {item.user}</Box>
            </Box>
            <Box component="h1" sx={{ color: "white", m: 3 }}>{item.title}</Box>
            <Box sx={{ color: "white", m: 2 }}>{item.description}</Box>
            {loadingState}
            <Box sx={{ m: 2 }}>
                <Box component="audio" controls src={downloadLink} />
            </Box>
            <Button variant="outlined" sx={{ m: 2 }}>
                <Link to={`/browse/${item.id}`}>Comments</Link>
            </Button>
        </Box>
    );
};
