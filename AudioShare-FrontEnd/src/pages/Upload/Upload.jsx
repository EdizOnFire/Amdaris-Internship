import { Button, TextField, Box, Input } from "@mui/material";
import { useState, useContext } from "react";
import { loginRequest } from "../../authConfig";
import { useNavigate } from "react-router-dom";
import { AuthContext } from "../../contexts/AuthContext";
import { useMsal } from "@azure/msal-react";
import * as itemService from "../../services/itemService";
import UploadIcon from '@mui/icons-material/Upload';
import KeyboardDoubleArrowDownIcon from '@mui/icons-material/KeyboardDoubleArrowDown';

export default function Upload() {
    const [audioFile, setAudioFile] = useState();
    const { instance, accounts } = useMsal();
    const { user } = useContext(AuthContext);
    const navigate = useNavigate();

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
                        navigate("/")
                    })
            });
        } catch (error) {
            return error;
        }
    };

    return (
        <Box component="section" id="uploadPage">
            <Box component="h1" sx={{ m: 4 }}>Upload Your Audio</Box>
            <Box
                component="form"
                sx={{
                    color: "inherit",
                    mx: 90,
                    textAlign: "center",
                }}
                onSubmit={onSubmit}
            >
                <Box component="div">
                    <Input
                        sx={{ p: 2, backgroundColor: "black", color: "white", border: 2, borderRadius: 2, borderColor: "#8d46ff", width: 420 }}
                        required
                        label="Title"
                        placeholder="Title of your thread"
                        name="title"
                    />
                </Box>
                <Button sx={{ m: 2 }} variant="contained" component="label">
                    <KeyboardDoubleArrowDownIcon /> Choose File
                    <Box component="input"
                        hidden
                        type="file"
                        accept="audio/*"
                        onChange={handleAudioUpload} />
                </Button>
                <Box id="fileName">
                    {audioFile ? <p>{audioFile.name}</p> : <p>No File Chosen</p>}
                </Box>

                <Box
                    component="textarea"
                    required
                    sx={{
                        p: 2,
                        font:"inherit",
                        border: 2,
                        borderRadius: 2,
                        borderColor: "#8d46ff",
                        maxWidth: 400,
                        maxHeight: 300,
                        fontSize: 17,
                        backgroundColor: "black",
                        color: "white",
                        height: 150,
                        width: 400,
                    }}
                    id="description"
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
            </Box>
        </Box>
    );
};