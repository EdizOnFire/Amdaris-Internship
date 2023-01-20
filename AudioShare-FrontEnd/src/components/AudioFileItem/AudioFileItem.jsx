import { useState } from "react";
import * as itemService from "../../services/itemService";
import { Box, Button } from '@mui/material';
import { useMsal } from "@azure/msal-react";
import { loginRequest } from "../../authConfig";

export default function AudioFileItem({ item }) {
    const { instance, accounts } = useMsal();
    const [download, setDownload] = useState("");
    const [loadingState, setLoadingState] = useState(".....");

    const onClick = (e) => {
        e.preventDefault();
        setLoadingState("Retrieving...");
        instance.acquireTokenSilent(
            {
                ...loginRequest,
                account: accounts[0]
            })
            .then((response) => {
                itemService
                    .download(item.path)
                    .then((response) => {
                        const url = URL.createObjectURL(response);
                        setDownload(url);
                        setLoadingState(".....");
                    })
                    .catch((error) => {
                        console.error(error);
                        setLoadingState("Failed");
                    });
            }
            )
    }

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
