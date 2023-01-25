import { useEffect, useState } from "react";
import { Box, Button } from "@mui/material";
import { Link } from "react-router-dom";
import * as itemService from "../../services/itemService";
import { styled } from "@mui/material/styles"
import Card from "@mui/material/Card"
import CardHeader from "@mui/material/CardHeader"
import CardMedia from "@mui/material/CardMedia"
import CardContent from "@mui/material/CardContent"
import CardActions from "@mui/material/CardActions"
import Avatar from "@mui/material/Avatar"
import IconButton from "@mui/material/IconButton"
import Typography from "@mui/material/Typography"
import { red } from "@mui/material/colors"
import FavoriteIcon from "@mui/icons-material/Favorite"
import ShareIcon from "@mui/icons-material/Share"
import CommentIcon from '@mui/icons-material/Comment';

export default function AudioFileItem({ item }) {
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
        <Card sx={{ maxWidth: 400, m: 6, display: "inline-block", backgroundColor: "#8d46ff", borderRadius: 4, color: "black" }}>
            <CardHeader
                avatar={
                    <Avatar sx={{ color: "black" }}>
                        {item?.user[0].toUpperCase()}
                    </Avatar>
                }
                title={`By: ${item?.user}`}
            />
            <Box>{item.title}</Box>
            <Box sx={{ m: 3 }} >
                <Box component="audio" controls src={downloadLink} />
            </Box>
            <Box>{loadingState}</Box>
            <CardContent>
                <Typography variant="body2" >
                    {`"${item.description}"`}
                </Typography>
            </CardContent>
            <CardActions disableSpacing>
                <Link to={`/browse/${item.id}`} >
                    <IconButton>
                        <CommentIcon sx={{ mx: 1 }} />
                    </IconButton>
                </Link>
            </CardActions>
        </Card>
    );
};