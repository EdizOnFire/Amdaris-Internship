import { useContext, useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import { Box, Button } from "@mui/material";
import { AuthContext } from "../../contexts/AuthContext";
import { useMsal } from "@azure/msal-react";
import { loginRequest } from "../../authConfig";
import * as itemService from "../../services/itemService";

export default function Details() {
    const [loadingState, setLoadingState] = useState("Retrieving...");
    const [downloadLink, setDownloadLink] = useState("");
    const [item, setItem] = useState();
    const { instance, accounts } = useMsal();
    const navigate = useNavigate();

    const { user } = useContext(AuthContext);
    const { id } = useParams();

    const isOwner = item?.user === user.username;

    useEffect(() => {
        itemService
            .getOne(id).then((result) => setItem(result))
            .catch((e) => { return e; });
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
                instance.acquireTokenSilent({
                    ...loginRequest,
                    account: accounts[0],
                }).then((response) => {
                    itemService.remove(response.accessToken, id, item.fileName)
                    navigate("/");
                })
            }
        } catch (error) {
            return error;
        }
    };

    return (
        <Box component="article" align="center" className="audioFile">
            <Box component="h1" sx={{ color: "white" }} className="itemTitle">
                Title: {item?.title}
            </Box>
            <Box className="itemName">File name: {item?.fileName}</Box>
            <Box className="itemFormat">Format: {item?.format}</Box>
            <Box>
                <Button href={downloadLink} download={item?.fileName}>
                    {loadingState}
                </Button>
            </Box>
            <Box>
                <audio controls src={downloadLink} />
            </Box>
            {isOwner && (
                <Box component="div" className="actionBtn">
                    <Button><Link to={`/browse/${id}/edit`}>Edit</Link></Button>
                    <Button onClick={itemDeleteHandler}>Delete</Button>
                </Box>
            )}
            <Box
                component="h1"
                sx={{ color: "white", m: 2 }}
                className="itemDescription">
                Description: {item?.description}
            </Box>
        </Box>
    );
}
