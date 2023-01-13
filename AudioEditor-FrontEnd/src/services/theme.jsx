import { ThemeProvider } from '@emotion/react'
import { createTheme } from '@mui/material'

export const theme = createTheme({
    palette: {
        primary: {
            main: "#4c00c5"
        },
    },
})

export const Theme = (props) => <ThemeProvider theme={theme}>{props.children}</ThemeProvider>