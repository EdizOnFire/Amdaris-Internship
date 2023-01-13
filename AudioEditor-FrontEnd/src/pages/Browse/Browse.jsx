import { Outlet } from "react-router-dom";

export default function Browse() {

    return (
        <section id="yourAudioFiles">
            <br />
            <div className="section-title">
                <h4>All Audio Files</h4>
            </div>
            <Outlet />
        </section>
    );
};
