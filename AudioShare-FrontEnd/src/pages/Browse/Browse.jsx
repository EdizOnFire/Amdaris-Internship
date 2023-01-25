import AudioFileItem from "../../components/AudioFileItem/AudioFileItem"
import SearchIcon from '@mui/icons-material/Search';
import { useEffect, useState } from "react";
import { Box, Grid, Input } from '@mui/material';
import * as itemService from "../../services/itemService";
import FeaturedPost from "../Home/FeaturedPost";

export default function Browse() {
    const [loadingState, setLoadingState] = useState("Loading...");
    const [items, setItems] = useState([]);
    const [query, setQuery] = useState();

    useEffect(() => {
        itemService.getAll()
            .then(result => setItems(result), setLoadingState(""))
            .catch(error => {
                setLoadingState("No files found")
                return error;
            })
    }, []);

    const getFilteredItems = (query, items) => {
        if (!query) {
            return items;
        }

        return items.filter(item => item.title.includes(query))
    }

    const filteredItems = getFilteredItems(query, items);

    return (
        <Box component="section" sx={{ display: 'block' }}>
            <Box component="h1" sx={{ m: 4 }}>All of the Posts</Box>
            <Box display="inline-block" sx={{ px: 1 }}>
                <SearchIcon sx={{ fontSize: 30, ml: 3 }} />
                <Input sx={{ p: 2, color: "white", my: 3, ml: 1, mr: 3, width: 300 }}
                    placeholder="Search..."
                    onChange={e => setQuery(e.target.value)} />
            </Box>
            <Grid container >
                {loadingState}
                {filteredItems?.map((x) => <FeaturedPost key={x.id} item={x} />)}
            </Grid>
        </Box>
    );
};
