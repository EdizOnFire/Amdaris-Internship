import { useContext, useEffect, useState } from "react";
import { AudioFileContext } from "../../contexts/AudioFileContext";
import { AuthContext } from "../../contexts/AuthContext";
import { Box } from "@mui/material";

export default function Profile() {
    const { items } = useContext(AudioFileContext);
    const { user } = useContext(AuthContext);
    const [number, setNumber] = useState();

    useEffect(() => {
        if (items.length > 0) {
            const userItems = items.filter((item) => item.user === user.username)
            setNumber(userItems.length);
        }
    }, [items])

    return (
        <Box
            component="section"
            align="center"
            sx={{ backgroundColor: "black", borderRadius: 6 }}
        >
            <Box component="h1" sx={{ mt: 4 }}>Profile</Box>
            <Box >
                <Box sx={{ px: 2, border: 2, borderColor: "black", borderRadius: 10, display: "inline-block", backgroundColor: "black" }}>
                    <Box sx={{ color: "#8d46ff", my: 2 }}>Name:</Box>
                    <Box component="h3" sx={{ px: 4 }}>
                        {user.name}
                    </Box>
                    <Box sx={{ color: "#8d46ff", my: 2 }}>Email: </Box>
                    <Box component="h3" sx={{ px: 4 }}>
                        {user.username}
                    </Box>
                    <Box sx={{ color: "#8d46ff", my: 2 }}>ID: </Box>
                    <Box component="h4" sx={{ px: 4 }}>
                        {user.localAccountId}
                    </Box>
                    <Box sx={{ color: "#8d46ff", my: 2 }}>No. of posts: </Box>
                    <Box component="h3" sx={{ px: 4 }}>
                        {number}
                    </Box>
                </Box>
            </Box>
        </Box>
    );
}
