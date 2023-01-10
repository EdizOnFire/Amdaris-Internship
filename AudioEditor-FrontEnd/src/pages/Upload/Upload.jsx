import { useState } from "react";
import * as itemService from "../../services/itemService";
import { Button, UploadIcon } from '@mui/material';

const Upload = () => {
    const [audioFiles, setAudioFiles] = useState([]);

    const handleAudioUpload = (e) => {
        console.log(Object.values(e.target.files));
        setAudioFiles(Object.values(e.target.files));
    };

    const onSubmit = (e) => {
        e.preventDefault();

        audioFiles.map((a) => {
            console.log(a);
            const formData = new FormData();
            formData.append("file", a);
            console.log(formData);
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
            <div className="section-title">
                <h4>Upload Your Audio Files</h4>
            </div>
            <div className="container" align="center">
                <form onSubmit={onSubmit}>
                    <label id="uploadLabel" />
                    <Button className="downloadButton" variant="contained" component="label">
                        Choose Files
                        <input hidden
                            type="file"
                            accept="audio/*"
                            onChange={handleAudioUpload}
                            multiple />
                    </Button>
                    <div id="fileName">
                        {audioFiles.length > 0 ? (
                            audioFiles.map((a) => <p key={a.name}>{a.name}</p>)
                        ) : (
                            <p>No File Chosen</p>
                        )}
                    </div>
                    <div>
                        <Button type="submit" className="detailsButton">
                            Upload
                        </Button>
                    </div>
                </form>
            </div>
        </section>
    );
};

export default Upload;
