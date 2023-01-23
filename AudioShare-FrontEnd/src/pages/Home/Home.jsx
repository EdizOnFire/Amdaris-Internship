import { Link } from "react-router-dom";

const Home = () => {
    return (
        <section id="welcomePage" align='center'>
            <h2>Welcome to </h2>
            <h1>Audio Share</h1>
            <p>Login and upload your audio file to get the best feedback by our community.</p>
            <p><Link to="/browse">Browse</Link> our forum to assist colleagues in need.</p>
            {/* <img src='/assets/images/homescreen.png' alt='Sorry.' id='homeImage' /> */}
        </section>
    );
};

export default Home;
