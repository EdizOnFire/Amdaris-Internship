import { loginRequest } from "../../authConfig";
import { AuthContext } from "../../contexts/AuthContext";
import { Box, Button } from "@mui/material";
import { useContext } from "react";
import { useMsal } from "@azure/msal-react";
import * as itemService from "../../services/itemService";

export default function Comment({ item }) {
    const { instance, accounts } = useMsal();
    const { user } = useContext(AuthContext);

    const isOwner = item.owner === user.username;

    const deleteHandler = (e) => {
        e.preventDefault();
        try {
            instance.acquireTokenSilent({
                ...loginRequest,
                account: accounts[0],
            }).then((response) => {
                itemService.removeComment(response.accessToken, user.username, item.id)
                    .then(e.target.parentNode.remove())
            });
        } catch (error) {
            return error;
        }
    };

    return (
        <Box>
            <Box sx={{ m: 2 }} className="comment">
                {item.owner}: {item.content}
                {isOwner &&
                    <Button sx={{ m: 2 }} variant="outlined" onClick={deleteHandler}>Delete</Button>
                }
            </Box>
        </Box>
    )
}
