import { Box, createTheme, Grid, ThemeProvider } from "@mui/material";
import { useEffect, useState } from "react";
import { Container } from "@mui/system";
import MainFeaturedPost from "../../components/MainFeaturedPost/MainFeaturedPost";
import FeaturedPost from "../../components/FeaturedPost/FeaturedPost";
import * as itemService from "../../services/itemService";

const mainFeaturedPost = {
    title: "Audio Share",
    description:
        "Get the best assistance from our community for your audio projects.",
    image: "/assets/images/maincontent.jpg",
    imageText: "main image description",
};

export default function Home() {
    const [loadingState, setLoadingState] = useState("Loading...");
    const [items, setItems] = useState([]);

    useEffect(() => {
        itemService
            .getAll()
            .then((result) => {
                setItems(result);
                setLoadingState("")
                if (result.length === 0) {
                    setLoadingState("No posts found");
                }
            })
            .catch((error) => {
                setLoadingState("No posts found");
                return error;
            });
    }, []);

    const theme = createTheme();

    return (
        <ThemeProvider theme={theme}>
            <Container >
                <MainFeaturedPost post={mainFeaturedPost} />
                <Box>
                    <Box component="h2" sx={{ display: "inline-block", borderRadius: 4, backgroundColor: "black", p: 2 }}>Featured Posts:</Box>
                    {loadingState &&
                        <Box>
                            <Box sx={{ display: "inline-block", borderRadius: 4, backgroundColor: "black", p: 2 }}>{loadingState}</Box>
                        </Box>
                    }
                    <Box>
                    </Box>
                    {items.map((post) => (
                        <FeaturedPost key={post.title} item={post} />
                    ))}
                </Box>
            </Container>
        </ThemeProvider>
    );
}
