import { useContext, useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { loginRequest } from "../../authConfig";
import { AuthContext } from "../../contexts/AuthContext";
import { Box, Button } from "@mui/material";
import { useMsal } from "@azure/msal-react";
import Comments from "../../components/Comments/Comments";
import * as itemService from "../../services/itemService";
import DownloadIcon from '@mui/icons-material/Download';
import EditIcon from '@mui/icons-material/Edit';
import DeleteForeverIcon from '@mui/icons-material/DeleteForever';

export default function Details() {
    const [loadingState, setLoadingState] = useState("Retrieving...");
    const [downloadLink, setDownloadLink] = useState("");
    const [item, setItem] = useState();
    const { instance, accounts } = useMsal();
    const { user } = useContext(AuthContext);
    const { id } = useParams();
    const navigate = useNavigate();

    const isOwner = item?.user === user?.username;

    useEffect(() => {
        itemService
            .getOne(id)
            .then((result) => setItem(result))
            .catch((e) => {
                return e;
            });
    }, []);

    useEffect(() => {
        if (item) {
            itemService
                .download(item.path)
                .then((response) => {
                    const url = URL.createObjectURL(response);
                    setDownloadLink(url);
                    setLoadingState("Download");
                })
                .catch((error) => {
                    setLoadingState("Failed");
                    return error;
                });
        }
    }, [item]);

    const itemDeleteHandler = () => {
        const confirmation = window.confirm(
            "Are you sure you want to delete this post?"
        );

        try {
            if (confirmation) {
                instance
                    .acquireTokenSilent({
                        ...loginRequest,
                        account: accounts[0],
                    })
                    .then((response) => {
                        itemService.remove(response.accessToken, id, item.fileName)
                        setTimeout(() => { navigate('/') }, 1500)
                    });
            }
        } catch (error) {
            return error;
        }
    };

    return (
        <Box
            component="article"
            display="inline-block"
            sx={{
                backgroundColor: "black",
                width: 1000,
                color: "#8d46ff",
                border: 2,
                m: 3,
                borderRadius: 4
            }}
            align="center"
            className="audioFile">
            <Box component="h1" sx={{ color: "white" }} className="itemTitle">
                {item?.title}
            </Box>
            <Box className="itemName">File name: {item?.fileName}</Box>
            <Box>
                <Button
                    variant="outlined"
                    sx={{ m: 3 }}
                    href={downloadLink}
                    download={item?.fileName}
                >
                    {downloadLink && <DownloadIcon sx={{ mr: 1 }} />}
                    {loadingState}
                </Button>
            </Box>
            <Box>
                <Box component="audio" controls src={downloadLink} />
            </Box>
            {isOwner && (
                <Box component="div" className="actionBtn">
                    <Button href={`/browse/${id}/edit`} sx={{ m: 3 }} variant="contained">
                        <EditIcon sx={{ mr: 1 }} />
                        Edit
                    </Button>
                    <Button sx={{ m: 3 }} variant="contained" onClick={itemDeleteHandler}>
                        <DeleteForeverIcon sx={{ mr: 1 }} />
                        Delete
                    </Button>
                </Box>
            )}
            <Box
                component="h1"
                sx={{ m: 2 }}
                className="itemDescription"
            >
                Description:
            </Box>
            <Box sx={{ color: "white" }}>{item?.description}</Box>
            <Comments />
        </Box>
    );
}
