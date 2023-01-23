import AudioFileItem from "./AudioFileItem/AudioFileItem"
import { useEffect, useState } from "react";
import * as itemService from "../../services/itemService";

export default function Browse() {
    const [items, setItems] = useState([]);
    const [loadingState, setLoadingState] = useState("Loading...");

    useEffect(() => {
        itemService.getAll()
            .then(result => setItems(result), setLoadingState("No files found"))
            .catch(error => {
                setLoadingState("No files found")
                return error;
            })
    }, []);

    return (
        <section id="yourAudioFiles">
            <br />
            <div className="section-title">
                <h4>All Audio Files</h4>
            </div>
            <div className="container" align="center">
                {items.length !== 0 ?
                    items.map((x) => <AudioFileItem key={x.id} item={x} />)
                    : <p>{loadingState}</p>
                }
            </div>
        </section>
    );
};
