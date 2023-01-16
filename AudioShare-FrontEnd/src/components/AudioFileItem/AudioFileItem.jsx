import { useState } from "react";
import * as itemService from "../../services/itemService";
import { Box, Button } from '@mui/material';

export default function AudioFileItem({ item }) {
    const [download, setDownload] = useState("");
    const [loadingState, setLoadingState] = useState(".....");

    const onClick = (e) => {
        e.preventDefault();

        setLoadingState("Retrieving...");
        itemService
            .download(item.path)
            .then((response) => response.blob())
            .then((newResponse) => {
                const url = URL.createObjectURL(newResponse);
                setDownload(url);
                setLoadingState(".....");
            })
            .catch((error) => {
                console.error(error);
                setLoadingState("Failed");
            });
    };

    return (
        <Box component="article" className="audioFile">
            <Box component="h1" sx={{ color: "white" }} className="itemTitle">Title: {item.title}</Box>
            <Box className="itemName">File name: {item.fileName}</Box>
            <Box className="itemFormat">Format: {item.format}</Box>
            <Box>
                <Button onClick={onClick} >
                    Load Audio
                </Button>
            </Box>
            {download ? (
                <Box>
                    <Button href={download} download={item.fileName}>
                        Download
                    </Button >
                </Box>
            ) : (
                <Box>
                    {loadingState}
                </Box>
            )}
            <Box>
                <audio controls src={download} />
            </Box>
            <Box component="h1" sx={{ color: "white", m: 2 }} className="itemDescription">Description: {item.description}</Box>
        </Box>
    );
};
