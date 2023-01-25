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
    const isAuthenticated = useIsAuthenticated();
    const [commentText, setCommentText] = useState("");
    const [comments, setComments] = useState([]);
    const { instance, accounts } = useMsal();
    const { user } = useContext(AuthContext);
    const { id } = useParams();

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
        <Box component="section" sx={{ mt: 16 }} align='center'>
            <Box component="h2">Comments:</Box>
            <Box sx={{ color: "white" }}>
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
                        sx={{ minWidth: 250, minHeight: 100 }}
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
};
