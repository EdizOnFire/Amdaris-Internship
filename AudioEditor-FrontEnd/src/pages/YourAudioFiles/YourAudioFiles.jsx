import { useState, useEffect } from "react";
import AudioFileItem from "../../components/AudioFileItem/AudioFileItem";
import * as itemService from "../../services/itemService";

const YourAudioFiles = () => {
    const [items, setItems] = useState([]);
    const [loadingState, setLoadingState] = useState("");

    useEffect(() => {
        setLoadingState("Loading...");
        itemService
            .getAll()
            .then((response) => {
                console.log(response.data);
                setItems(response.data);
                setLoadingState("");
                if (response.data.length === 0) {
                    setLoadingState("No files found");
                }
            })
            .catch((response) => {
                console.log(response);
                setLoadingState("Error in loading");
            });
    }, []);

    return (
        <section id="yourAudioFiles">
            <br />
            <div className="section-title">
                <h4>All Audio Files</h4>
            </div>
            <div className="container" align="center">
                <p>{loadingState}</p>
                {items?.length > 0 &&
                    items.map((x) => <AudioFileItem key={x.id} item={x} />)}
            </div>
        </section>
    );
};

export default YourAudioFiles;
