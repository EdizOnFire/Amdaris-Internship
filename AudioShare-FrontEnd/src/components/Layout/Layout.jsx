import { Outlet, useNavigation } from "react-router-dom";
import Footer from "../Footer/Footer";
import Navbar from "../Navbar/Navbar";

export default function Layout() {
    const navigation = useNavigation()

    return (
        <>
            <Navbar />
            <main>
                {navigation.state === "loading" ? <p align="center">Loading...</p> : <Outlet />}
            </main>
            <Footer />
        </>
    )
}
