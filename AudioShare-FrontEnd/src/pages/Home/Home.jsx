import { Box, createTheme, Grid, ThemeProvider } from "@mui/material";
import MainFeaturedPost from "./MainFeaturedPost";
import FeaturedPost from "./FeaturedPost";
import { Container } from "@mui/system";
import { useEffect, useState } from "react";
import * as itemService from "../../services/itemService";
import AudioFileItem from "../../components/AudioFileItem/AudioFileItem";

const mainFeaturedPost = {
    title: "Audio Share",
    description:
        "Get the best assistance from our community for your audio projects.",
    image: "/assets/images/home2.jpg",
    imageText: "main image description",
};

export default function Home() {
    const [items, setItems] = useState([]);

    useEffect(() => {
        itemService.getAll()
            .then(result => setItems(result))
            .catch(error => {
                return error;
            })
    }, []);

    const theme = createTheme();

    return (
        <ThemeProvider theme={theme}>
            <Container >
                <MainFeaturedPost post={mainFeaturedPost} />
                <Box component="h2" sx={{ mt: 8 }}>Featured Posts:</Box>
                <Grid container sx={{ m: 1 }} spacing={4}>
                    {items.map((post) => (
                        <AudioFileItem key={post.title} item={post} />
                    ))}
                </Grid>
            </Container>
        </ThemeProvider>
    );
};
