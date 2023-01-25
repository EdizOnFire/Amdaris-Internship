import PropTypes from 'prop-types';
import Typography from '@mui/material/Typography';
import Grid from '@mui/material/Grid';
import Card from '@mui/material/Card';
import CardActionArea from '@mui/material/CardActionArea';
import CardContent from '@mui/material/CardContent';
import { Avatar, Box, CardActions, CardHeader, IconButton } from '@mui/material';
import { useEffect, useState } from 'react';
import * as itemService from "../../services/itemService";
import { Link } from 'react-router-dom';
import CommentIcon from '@mui/icons-material/Comment';

function FeaturedPost({ item }) {
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
    <Grid  item xs={16} md={4} >
      <Card sx={{ display: 'inline-block', backgroundColor: "#8d46ff", borderRadius: 6, m: 10, boxShadow: 10 }}>
        <CardContent sx={{ flex: 1 }}>
          <CardHeader
            avatar={
              <Avatar sx={{ color: "black" }}>
                {item?.user[0].toUpperCase()}
              </Avatar>
            }
            title={`By: ${item?.user}`}
          />
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
            <Link to={`/browse/${item.id}`} >
              <IconButton sx={{ size: 100 }} >
                <CommentIcon sx={{ mx: 1 }} />Comments
              </IconButton>
            </Link>
        </CardContent>
      </Card>
    </Grid>
  );
}

FeaturedPost.propTypes = {
  item: PropTypes.shape({
    description: PropTypes.string.isRequired,
    title: PropTypes.string.isRequired,
  }).isRequired,
};

export default FeaturedPost;
