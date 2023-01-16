import { useState } from "react";
import * as itemService from "../../services/itemService";
import { Button, TextField } from '@mui/material';
import Box from '@mui/material/Box';

const Upload = () => {
    const [audioFiles, setAudioFiles] = useState("");

    const handleAudioUpload = (e) => {
        console.log(Object.values(e.target.files));
        setAudioFiles(Object.values(e.target.files));
    };

    const onSubmit = (e) => {
        e.preventDefault();

        audioFiles.map((a) => {
            const formData = new FormData();
            formData.append("file", a);
            itemService.upload(formData)
                .then(setAudioFiles([]))
                .catch((error) => {
                    console.log(error);
                });
        });
    };

    return (
        <section id="uploadPage">
            <br />
            <Box sx={{ mx: 90 }} className="section-title">
                <h4>Upload Your Audio File </h4>
            </Box>
            <Box component="form"
                sx={{
                    color: "#4c00c5",
                    mx: 90,
                    border: 1,
                    textAlign: "center"
                }} onSubmit={onSubmit}>
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
                        autoFocus />
                </Box>
                <Button sx={{ m: 2 }} variant="contained" component="label">
                    Choose File
                    <input hidden
                        type="file"
                        accept="audio/*"
                        onChange={handleAudioUpload} />
                </Button>
                <Box id="fileName">
                    {audioFiles.length > 0 ? (
                        audioFiles.map((a) => <p key={a.name}>{a.name}</p>)
                    ) : (
                        <p>No File Chosen</p>
                    )}
                </Box>

                <Box component="textarea" required
                    sx={{ maxWidth: 400, fontSize: 17, backgroundColor: "white", height: 150, width: 299 }}
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

export default Upload;
