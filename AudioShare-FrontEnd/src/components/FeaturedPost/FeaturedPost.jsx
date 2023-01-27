import { CardHeader, CardContent, CardActions, IconButton, Typography, Box, Card, Avatar, } from "@mui/material";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import CommentIcon from "@mui/icons-material/Comment";
import PropTypes from "prop-types";
import * as itemService from "../../services/itemService";

export default function FeaturedPost({ item }) {
    const [loadingState, setLoadingState] = useState("Retrieving...");
    const [downloadLink, setDownloadLink] = useState("");

    useEffect(() => {
        if (item) {
            itemService
                .download(item.path)
                .then((response) => {
                    const url = URL.createObjectURL(response);
                    setDownloadLink(url);
                    setLoadingState("Loaded");
                })
                .catch((error) => {
                    setLoadingState("Failed");
                    return error;
                });
        }
    }, [item]);

    return (
        <Card
            sx={{
                height: 340,
                width: 400,
                maxHeight: 340,
                maxWidth: 400,
                m: 6,
                display: "inline-block",
                backgroundColor: "#8d46ff",
                borderRadius: 4,
                color: "black",
            }}
        >
            <CardHeader
                avatar={
                    <Avatar sx={{ color: "black" }}>{item?.user[0].toUpperCase()}</Avatar>
                }
                title={`By: ${item?.user}`}
            />
            <Box>{item.title}</Box>
            <Box sx={{ m: 3 }}>
                <Box component="audio" controls src={downloadLink} />
            </Box>
            <Box>{loadingState}</Box>
            <CardContent>
                <Typography variant="body2">{`"${item.description}"`}</Typography>
            </CardContent>
            <CardActions disableSpacing>
                <Link to={`/browse/${item.id}`}>
                    <IconButton>
                        <CommentIcon sx={{ mx: 1 }} />
                    </IconButton>
                </Link>
            </CardActions>
        </Card>
    );
}

FeaturedPost.propTypes = {
    item: PropTypes.shape({
        description: PropTypes.string.isRequired,
        title: PropTypes.string.isRequired,
    }).isRequired,
};
