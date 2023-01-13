import { Link } from "react-router-dom";

const Home = () => {
    return (
        <section id="welcomePage" align='center'>
            <h2>Welcome to </h2>
            <h1>Audio Editor</h1>
            <p>Click <Link to="/upload">here</Link> to upload your audio files.</p>
            {/* <img src='/assets/images/homescreen.png' alt='Sorry.' id='homeImage' /> */}
        </section>
    );
};

export default Home;
