import { useEffect, useContext, useState } from "react";
import { useIsAuthenticated, useMsal } from "@azure/msal-react";
import { loginRequest } from "../../authConfig";
import { AuthContext } from "../../contexts/AuthContext";
import { Box, Button } from "@mui/material";
import { useParams } from "react-router-dom";
import * as itemService from "../../services/itemService";
import CommentItem from "../CommentItem/CommentItem";
import AddCommentIcon from '@mui/icons-material/AddComment';

export default function Comments() {
    const [commentText, setCommentText] = useState("");
    const [comments, setComments] = useState([]);
    const { instance, accounts } = useMsal();
    const { user } = useContext(AuthContext);
    const { id } = useParams();
    const isAuthenticated = useIsAuthenticated();

    const addCommentHandler = (e) => {
        e.preventDefault();

        const comment = { owner: user.username, content: commentText, audioFileId: id }
        try {
            instance.acquireTokenSilent({
                ...loginRequest,
                account: accounts[0],
            }).then((response) => {
                itemService.addComment(response.accessToken, comment)
                setTimeout(() => { setCommentText("") }, 200)
            });
        } catch (error) {
            return error;
        }
    };

    useEffect(() => {
        itemService.getAllComments()
            .then(result => setComments(
                result.filter(x => x.audioFileId == id))
            )
    }, [commentText])

    return (
        <Box component="section" sx={{ px: 2, mt: 4, border: 2, borderColor: "black", borderRadius: 10, display: "inline-block", backgroundColor: "black" }}
            align='center'>
            <Box component="h2" sx={{ color: "#8d46ff" }}>Comments:</Box>
            <Box sx={{ mt: 3 }}>
                {comments?.length > 0 ? (
                    comments.map((x) => (
                        <CommentItem key={x.id} item={x} />
                    ))
                ) : (
                    <p className="no-comment">No comments.</p>
                )}
            </Box>
            {isAuthenticated && (
                <Box component="form" align="center" onSubmit={addCommentHandler}>
                    <Box component="textarea"
                        name="comment"
                        sx={{
                            p: 2,
                            font: "inherit",
                            border: 2,
                            borderRadius: 2,
                            borderColor: "#8d46ff",
                            fontSize: 17,
                            backgroundColor: "black",
                            color: "white",
                            minWidth: 400,
                            minHeight: 20,
                            width: 400,
                            height: 20,
                            maxWidth: 400,
                            maxHeight: 150,
                        }}
                        placeholder="Comment..."
                        value={commentText}
                        onChange={e => setCommentText(e.target.value)} />
                    <Box>
                        <Button sx={{ m: 3 }} variant="contained" type="submit"><AddCommentIcon sx={{ mr: 1 }} />Comment</Button>
                    </Box>
                </Box>
            )}
        </Box>
    );
}
