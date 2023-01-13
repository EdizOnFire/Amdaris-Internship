import * as React from 'react';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { Form, NavLink, redirect } from 'react-router-dom';

export default function Login() {
    return (
        <Container component="section" maxWidth="xs">
            <Box
                sx={{

                    marginTop: 8,
                    display: 'flex',
                    flexDirection: 'column',
                    alignItems: 'center',
                }}>
                <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
                    <LockOutlinedIcon />
                </Avatar>
                <Typography component="h1" sx={{ color: "white" }} variant="h5">
                    Login
                </Typography>
                <Form method='post' align="center" action='/login' noValidate sx={{ mt: 1 }}>
                    <TextField
                        margin="normal"
                        required
                        id="email"
                        label="Email Address"
                        name="email"
                        autoComplete="email"
                        autoFocus
                    />
                    <TextField
                        margin="normal"
                        required
                        name="password"
                        label="Password"
                        type="password"
                        id="password"
                        autoComplete="current-password"
                    />
                    <Box component="div">
                        <FormControlLabel sx={{ color: "white" }}
                            control={<Checkbox value="remember" color="primary" />}
                            label="Remember me"
                        />
                    </Box>
                    <Box component="div">
                        <Button
                            type="submit"
                            variant="contained"
                            sx={{ mt: 3, mb: 2 }}
                        >
                            Login
                        </Button>
                    </Box>
                    <Grid item>
                        <NavLink to="/register" variant="body2">
                            {"Don't have an account? Register"}
                        </NavLink>
                    </Grid>
                </Form>
            </Box>
        </Container>
    );
}

export const submitLogin = async ({ request }) => {
    console.log(request);
    const { email, password } = Object.fromEntries(await request.formData());
    console.log({ email, password });
    return redirect('/')
};