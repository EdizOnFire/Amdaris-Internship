import { useNavigate, useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { loginRequest } from "../../authConfig";
import { Box, Button } from "@mui/material";
import { useMsal } from "@azure/msal-react";
import * as itemService from "../../services/itemService";

export default function Edit() {
    const [audioFile, setAudioFile] = useState();
    const { instance, accounts } = useMsal();
    const { id } = useParams();
    const navigate = useNavigate();

    useEffect(() => {
        itemService
            .getOne(id).then((result) => setAudioFile(result))
            .catch((e) => { return e; });
    }, []);

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
                        .then(navigate("/"))
                });
        } catch (error) {
            return error;
        }
    };

    return (
        <Box component="article" align="center" className="audioFile">
            <Box component="form" sx={{ m: 3 }} onSubmit={onSubmit}>
                <Box className="itemName">Title: <Box name="title" component="input" defaultValue={audioFile?.title} /></Box>
                <Box className="itemName">File name: {audioFile?.fileName}</Box>
                <Box className="itemFormat">Format: {audioFile?.format}</Box>
                <Box className="itemName">Description: <Box name="description" component="input" defaultValue={audioFile?.description} /></Box>
                <Button sx={{ m: 2 }} type="submit">
                    Edit
                </Button>
            </Box>
        </Box>
    );
}
