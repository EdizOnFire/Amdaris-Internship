import { Link } from "react-router-dom";

const Header = () => {
    return (
        <header>
            <nav>
                <ul>
                    <li><Link to="/">
                        Home
                    </Link></li>
                    <li><Link to="/your-audio-files">
                        Your Audio Files
                    </Link></li>
                    <li><Link to="/upload">
                        Upload
                    </Link></li>
                </ul>
            </nav>
        </header>
    );
};

export default Header;
