import { useEffect, useState } from "react";
import { Box, Grid, Input } from "@mui/material";
import AudioFileItem from "../../components/AudioFileItem/AudioFileItem";
import SearchIcon from "@mui/icons-material/Search";
import * as itemService from "../../services/itemService";

export default function Browse() {
    const [loadingState, setLoadingState] = useState("Loading...");
    const [items, setItems] = useState([]);
    const [query, setQuery] = useState();

    useEffect(() => {
        itemService
            .getAll()
            .then((result) => {
                setItems(result);
                setLoadingState("");
                if (result.length === 0) {
                    setLoadingState("No posts found");
                }
            })
            .catch((error) => {
                setLoadingState("No posts found");
                return error;
            });
    }, []);

    const getFilteredItems = (query, items) => {
        if (!query) {
            return items;
        }

        return items.filter((item) => item.title.toLowerCase().includes(query.toLowerCase()));;
    };

    const filteredItems = getFilteredItems(query, items);

    return (
        <Box component="section" sx={{ display: "inline-block" }}>
            <Box component="h1" sx={{ borderRadius: 4, backgroundColor: "black", p: 2, display: "inline-block" }}>
                All of the Posts
            </Box>
            <Box display="block" sx={{ px: 1 }}>
                <SearchIcon sx={{ fontSize: 30, ml: 3 }} />
                <Input
                    sx={{ p: 2, color: "white", my: 3, ml: 1, mr: 3, width: 300 }}
                    placeholder="Search..."
                    onChange={(e) => setQuery(e.target.value)}
                />
            </Box>
            <Grid container>
                {loadingState}
                {filteredItems?.map((x) => (
                    <AudioFileItem key={Math.random(9999)} item={x} />
                ))}
            </Grid>
        </Box>
    );
}
