import { useState, useContext, forwardRef, useRef } from "react";
import { Button, Box, Snackbar } from "@mui/material";
import { loginRequest } from "../../authConfig";
import { AuthContext } from "../../contexts/AuthContext";
import { useMsal } from "@azure/msal-react";
import KeyboardDoubleArrowDownIcon from '@mui/icons-material/KeyboardDoubleArrowDown';
import UploadIcon from '@mui/icons-material/Upload';
import MuiAlert from '@mui/material/Alert';
import * as itemService from "../../services/itemService";

const Alert = forwardRef(function Alert(props, ref) {
    return <MuiAlert elevation={6} ref={ref} variant="filled" {...props} />;
});

export default function Upload() {
    const [audioFile, setAudioFile] = useState();
    const { instance, accounts } = useMsal();
    const { user } = useContext(AuthContext);
    const [open, setOpen] = useState(false);
    const formRef = useRef();

    const handleClose = (event, reason) => {
        if (reason === 'clickaway') {
            return;
        }

        setOpen(false);
    };

    const handleAudioUpload = (e) => {
        setAudioFile(e.target.files[0]);
    };

    const onSubmit = (e) => {
        e.preventDefault();
        const formData = new FormData(e.target);
        const title = formData.get("title");
        const description = formData.get("description");

        const formFileData = new FormData();
        formFileData.append("file", audioFile);
        setAudioFile({ name: "Uploading..." });
        try {
            instance.acquireTokenSilent({
                ...loginRequest,
                account: accounts[0],
            }).then((response) => {
                itemService.upload(
                    response.accessToken,
                    formFileData,
                    title,
                    description,
                    user.username)
                    .then(() => {
                        setOpen(true);
                        setAudioFile("");
                        formRef.current.reset()
                    })
            });
        } catch (error) {
            return error;
        }
    };

    return (
        <Box component="section">
            <Box component="h1" sx={{ borderRadius: 4, backgroundColor: "black", p: 2, display: "inline-block" }}>Upload Your Audio</Box>
            <Box ref={formRef}
                component="form"
                sx={{
                    color: "inherit",
                    mx: 90,
                    textAlign: "center",
                }}
                onSubmit={onSubmit}
            >
                <Box >
                    <Box component="input"
                        sx={{ font: "inherit", fontSize: 16, p: 2, mb: 4, backgroundColor: "black", color: "white", border: 2, borderRadius: 2, borderColor: "#8d46ff", width: 460 }}
                        required
                        label="Title"
                        placeholder="Title of your thread"
                        name="title"
                    />
                </Box>
                <Button variant="contained" component="label">
                    <KeyboardDoubleArrowDownIcon /> Choose File
                    <Box component="input"
                        hidden
                        type="file"
                        accept="audio/*"
                        onChange={handleAudioUpload} />
                </Button>
                <Box sx={{ mb: 4, mt: 2 }}>
                    {audioFile ? <Box>{audioFile.name}</Box> : <Box>No File Chosen</Box>}
                </Box>
                <Box
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
                >
                </Box>
                <Box>
                    <Button variant="contained" sx={{ m: 2 }} type="submit">
                        <UploadIcon />Upload
                    </Button>
                </Box>
                <Snackbar anchorOrigin={{ vertical: 'top', horizontal: 'right' }} open={open} autoHideDuration={6000} onClose={handleClose}>
                    <Alert onClose={handleClose} severity="success" sx={{ width: '100%' }}>
                        Uploaded successfully!
                    </Alert>
                </Snackbar>
            </Box>
        </Box>
    );
}
