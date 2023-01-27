import { forwardRef, useEffect, useState } from "react";
import { Box, Button, Snackbar } from "@mui/material";
import { useNavigate, useParams } from "react-router-dom";
import { loginRequest } from "../../authConfig";
import { useMsal } from "@azure/msal-react";
import SaveIcon from '@mui/icons-material/Save';
import MuiAlert from '@mui/material/Alert';
import * as itemService from "../../services/itemService";

const Alert = forwardRef(function Alert(props, ref) {
    return <MuiAlert elevation={6} ref={ref} variant="filled" {...props} />;
});

export default function Edit() {
    const [audioFile, setAudioFile] = useState();
    const [open, setOpen] = useState(false);
    const { instance, accounts } = useMsal();
    const { id } = useParams();
    const navigate = useNavigate();

    const handleClose = (event, reason) => {
        if (reason === 'clickaway') {
            return;
        }

        setOpen(false);
    };

    useEffect(() => {
        itemService
            .getOne(id).then((result) => setAudioFile(result))
            .catch((e) => { return e; });
    }, [id]);

    const onSubmit = (e) => {
        e.preventDefault();
        const formData = new FormData(e.target);
        const title = formData.get("title");
        const description = formData.get("description");

        audioFile.title = title;
        audioFile.description = description;
        try {
            instance.acquireTokenSilent({
                ...loginRequest,
                account: accounts[0],
            })
                .then((response) => {
                    itemService.edit(
                        response.accessToken,
                        audioFile.id,
                        audioFile)
                    setOpen(true);
                    setTimeout(() => {
                        navigate("/browse/" + audioFile.id)
                    }, 500)
                });
        } catch (error) {
            return error;
        }
    };

    return (
        <Box
            component="section"
            display="inline-block"
            sx={{ backgroundColor: "black", borderRadius: 6 }}
        >
            <Box component="form" onSubmit={onSubmit}>
                <Box sx={{ px: 2, mt: 4, border: 2, borderColor: "black", borderRadius: 10, display: "inline-block", backgroundColor: "black" }} >
                    <Box component="h1" sx={{ color: "#8d46ff" }}>Title:</Box>
                    <Box component="input" defaultValue={audioFile?.title}
                        sx={{ font: "inherit", fontSize: 16, p: 2, mb: 4, backgroundColor: "black", color: "white", border: 2, borderRadius: 2, borderColor: "#8d46ff", width: 460 }}
                        required
                        label="Title"
                        placeholder="Title of your thread"
                        name="title"
                    />
                </Box>
                <Box >
                    <Box sx={{ px: 2, mt: 4, border: 2, borderColor: "black", borderRadius: 10, display: "inline-block", backgroundColor: "black" }}>
                        <Box component="h2" sx={{ color: "#8d46ff" }} >File name: </Box>
                        <Box component="h3" sx={{ mb: 4 }} >{audioFile?.fileName}</Box>
                    </Box>
                </Box>
                <Box >
                    <Box sx={{ px: 2, mt: 4, border: 2, borderColor: "black", borderRadius: 10, display: "inline-block", backgroundColor: "black" }}>
                        <Box component="h1" sx={{ color: "#8d46ff" }}>Description:</Box>
                        <Box
                            defaultValue={audioFile?.description}
                            component="textarea"
                            required
                            sx={{
                                p: 2,
                                font: "inherit",
                                border: 2,
                                borderRadius: 2,
                                borderColor: "#8d46ff",
                                fontSize: 17,
                                backgroundColor: "black",
                                color: "white",
                                minWidth: 450,
                                minHeight: 120,
                                width: 450,
                                height: 120,
                                maxWidth: 450,
                                maxHeight: 350,
                            }}
                            label="Description"
                            placeholder="What you need feedback for"
                            name="description"
                        ></Box>
                        <Box>
                            <Button variant="contained" sx={{ m: 3 }} type="submit">
                                <SaveIcon sx={{ mr: 1 }} />
                                Save
                            </Button>
                        </Box>
                    </Box>
                </Box>
                <Snackbar anchorOrigin={{ vertical: 'top', horizontal: 'right' }} open={open} autoHideDuration={6000} onClose={handleClose}>
                    <Alert onClose={handleClose} severity="success" sx={{ width: '100%' }}>
                        Edit successful!
                    </Alert>
                </Snackbar>
            </Box>
        </Box>
    );
}
