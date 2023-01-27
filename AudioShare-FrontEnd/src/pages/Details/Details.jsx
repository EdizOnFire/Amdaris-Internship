import { forwardRef, useContext, useEffect, useState } from "react";
import { useNavigate, useParams, Link } from "react-router-dom";
import { loginRequest } from "../../authConfig";
import { AuthContext } from "../../contexts/AuthContext";
import { Box, Button, Snackbar } from "@mui/material";
import { useMsal } from "@azure/msal-react";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";
import DownloadIcon from "@mui/icons-material/Download";
import Comments from "../../components/Comments/Comments";
import EditIcon from "@mui/icons-material/Edit";
import MuiAlert from '@mui/material/Alert';
import * as itemService from "../../services/itemService";

const Alert = forwardRef(function Alert(props, ref) {
    return <MuiAlert elevation={6} ref={ref} variant="filled" {...props} />;
});

export default function Details() {
    const [loadingState, setLoadingState] = useState("Retrieving...");
    const [downloadLink, setDownloadLink] = useState("");
    const [item, setItem] = useState();
    const [open, setOpen] = useState(false);
    const { instance, accounts } = useMsal();
    const { user } = useContext(AuthContext);
    const { id } = useParams();
    const navigate = useNavigate();

    const handleClose = (event, reason) => {
        if (reason === 'clickaway') {
            return;
        }

        setOpen(false);
    };

    const isOwner = item?.user === user?.username;

    useEffect(() => {
        itemService
            .getOne(id)
            .then((result) => setItem(result))
            .catch((e) => {
                return e;
            });
    }, [id]);

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
                })
                    .then((response) => {
                        itemService.remove(response.accessToken, id, item.fileName);
                        setOpen(true);
                        setTimeout(() => {
                            navigate("/browse");
                        }, 1500);
                    });
            }
        } catch (error) {
            return error;
        }
    };

    return (
        <Box
        component="section"
        align="center"
            sx={{ backgroundColor: "black", borderRadius: 6 }}
        >
            <Box >
                <Box sx={{ px: 2, mt: 4, border: 2, borderColor: "black", borderRadius: 10, display: "inline-block", backgroundColor: "black" }}>
                    <Box sx={{ color: "#8d46ff", mt: 2 }}>By: {user.username}</Box>
                    <Box component="h1" sx={{ px: 4 }}>
                        {item?.title}
                    </Box>
                    <Box sx={{ color: "#8d46ff", mb: 2 }}>File name: {item?.fileName}</Box>
                </Box>
            </Box>
            <Box>
                <Box sx={{ px: 2, border: 2, borderColor: "black", borderRadius: 10, display: "inline-block", backgroundColor: "black" }}>
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
                        <Box component="div">
                            <Link to={`/browse/${id}/edit`}>
                                <Button sx={{ m: 3 }} variant="contained">
                                    <EditIcon sx={{ mr: 1 }} />
                                    Edit
                                </Button>
                            </Link>
                            <Button sx={{ m: 3 }} variant="contained" onClick={itemDeleteHandler}>
                                <DeleteForeverIcon sx={{ mr: 1 }} />
                                Delete
                            </Button>
                        </Box>
                    )}
                </Box>
            </Box>
            <Box>
                <Box sx={{ px: 2, mt: 4, border: 2, borderColor: "black", borderRadius: 10, display: "inline-block", backgroundColor: "black" }}>
                    <Box component="h1" sx={{ color: "#8d46ff", m: 2 }}>
                        Description:
                    </Box>
                    <Box sx={{ my: 4 }}>{item?.description}</Box>
                </Box>
            </Box>
            <Comments />
            <Snackbar anchorOrigin={{ vertical: 'top', horizontal: 'right' }} open={open} autoHideDuration={6000} onClose={handleClose}>
                <Alert onClose={handleClose} severity="success" sx={{ width: '100%' }}>
                    Deleted successfully!
                </Alert>
            </Snackbar>
        </Box>
    );
}
