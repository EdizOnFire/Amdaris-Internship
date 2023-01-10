import { ThemeProvider } from '@emotion/react'
import { createTheme } from '@mui/material'

export const theme = createTheme({
    palette: {
        primary: {
            main: "#9552ff",
        },
    },
    components: {
        MuiButton: {
            styleOverrides: {
                outlined: {
                    borderRadius: '20px',
                },
            },
        },
    },
})

export const Theme = (props) => <ThemeProvider theme={theme}>{props.children}</ThemeProvider>