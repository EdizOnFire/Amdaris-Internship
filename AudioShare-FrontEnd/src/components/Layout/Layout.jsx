import { Outlet, useNavigation } from "react-router-dom";
import { Box } from "@mui/material";
import Footer from "../Footer/Footer";
import Navbar from "../Navbar/Navbar";

export default function Layout() {
    const navigation = useNavigation();

    return (
        <>
            <Navbar />
            <Box component="main" sx={{ display: 'inline-block' }} align="center">
                {navigation.state === "loading" ? <p align="center">Loading...</p> : <Outlet />}
            </Box >
            <Footer />
        </>
    );
}
