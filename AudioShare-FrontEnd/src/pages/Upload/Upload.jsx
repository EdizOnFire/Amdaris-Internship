import { Button, TextField, Box } from "@mui/material";
import { useState, useContext } from "react";
import { AudioFileContext } from "../../contexts/AudioFileContext";
import { loginRequest } from "../../authConfig";
import { useNavigate } from "react-router-dom";
import { AuthContext } from "../../contexts/AuthContext";
import { useMsal } from "@azure/msal-react";
import * as itemService from "../../services/itemService";

export default function Upload() {
    const { instance, accounts } = useMsal();
    const [audioFile, setAudioFile] = useState();
    const { itemAdd } = useContext(AudioFileContext);
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
                        setAudioFile("")
                        itemAdd(audioFile)
                        navigate("/")
                    })
            });
        } catch (error) {
            return error;
        }
    };

    return (
        <section id="uploadPage">
            <br />
            <Box sx={{ mx: 90 }} className="section-title">
                <h4>Upload Your Audio File </h4>
            </Box>
            <Box
                component="form"
                sx={{
                    color: "#4c00c5",
                    mx: 90,
                    border: 1,
                    textAlign: "center",
                }}
                onSubmit={onSubmit}
            >
                <label id="uploadLabel" />
                <Box component="div">
                    <TextField
                        sx={{ backgroundColor: "white", width: 300 }}
                        margin="normal"
                        required
                        id="title"
                        label="Title"
                        placeholder="Title of your thread"
                        name="title"
                        autoFocus
                    />
                </Box>
                <Button sx={{ m: 2 }} variant="contained" component="label">
                    Choose File
                    <input
                        hidden
                        type="file"
                        accept="audio/*"
                        onChange={handleAudioUpload}
                    />
                </Button>
                <Box id="fileName">
                    {audioFile ? <p>{audioFile.name}</p> : <p>No File Chosen</p>}
                </Box>

                <Box
                    component="textarea"
                    required
                    sx={{
                        maxWidth: 400,
                        fontSize: 17,
                        backgroundColor: "white",
                        height: 150,
                        width: 299,
                    }}
                    id="description"
                    margin="normal"
                    label="Description"
                    placeholder="What you need feedback for"
                    name="description"
                    autoFocus>
                </Box>
                <Box>
                    <Button sx={{ m: 2 }} type="submit">
                        Upload
                    </Button>
                </Box>
            </Box>
        </section>
    );
};
