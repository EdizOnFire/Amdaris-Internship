import { Avatar, Box, CardActions, CardHeader, IconButton, CardContent, Typography, Grid, Card } from '@mui/material';
import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import CommentIcon from '@mui/icons-material/Comment';
import * as itemService from "../../services/itemService";

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
    <Card sx={{ display: 'inline-block', backgroundColor: "#8d46ff", borderRadius: 6, m: 10, boxShadow: 10, width: 450 }}>
      <CardContent>
        <CardHeader
          avatar={
            <Avatar sx={{ color: "black" }} >{item?.user[0].toUpperCase()}</Avatar>
          } title={`By: ${item.user}`} sx={{ p: 0 }} />
        <Typography component="h2" sx={{ m: 2 }} variant="h5">
          {item.title}
        </Typography>
        <Typography variant="subtitle1" sx={{ m: 2 }} color="text.secondary">
          {item.fileName}
        </Typography>
        <Typography variant="subtitle1" sx={{ m: 2 }} paragraph>
          {item.description}
        </Typography>
        <Box component="audio" src={downloadLink} controls sx={{ m: 1 }} />
        <Typography variant="subtitle1" >
          {loadingState}
        </Typography>
        <CardActions sx={{ bottom: 0, top: 0 }} disableSpacing>
          <Link to={`/browse/${item.id}`}>
            <IconButton>
              <CommentIcon sx={{ mx: 1 }} />Comments
            </IconButton>
          </Link>
        </CardActions>
      </CardContent>
    </Card>
  );
}
