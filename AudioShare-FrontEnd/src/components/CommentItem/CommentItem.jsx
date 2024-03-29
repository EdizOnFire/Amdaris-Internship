import { loginRequest } from "../../authConfig";
import { AuthContext } from "../../contexts/AuthContext";
import { Box, Button } from "@mui/material";
import { useContext } from "react";
import { useMsal } from "@azure/msal-react";
import DeleteOutlineIcon from '@mui/icons-material/DeleteOutline';
import * as itemService from "../../services/itemService";

export default function CommentItem({ item }) {
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
            <Box sx={{ m: 2 }} >
                <Box sx={{ color: "#8d46ff", display: "inline" }}>{`${item.owner}: `}</Box><Box sx={{ display: "inline" }}>{item.content}</Box>
                {isOwner &&
                    <Button sx={{ mx: 2 }} variant="outlined" onClick={deleteHandler}><DeleteOutlineIcon />Delete</Button>
                }
            </Box>
        </Box>
    );
}
