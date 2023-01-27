import { ThemeProvider } from "@emotion/react";
import { createTheme } from "@mui/material";

export const theme = createTheme({
    palette: {
        primary: {
            main: "#8d46ff",
        },
    },
});

export const Theme = (props) => (
    <ThemeProvider theme={theme}>{props.children}</ThemeProvider>
);
