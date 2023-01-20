import AudioFileItem from "../../components/AudioFileItem/AudioFileItem"
import * as itemService from "../../services/itemService";
import { useState, useEffect } from "react";

export default function Browse() {
    const [items, setItems] = useState([]);
    const [loadingState, setLoadingState] = useState('Loading...');

    useEffect(() => {
        itemService.getAll()
            .then(result => {
                setItems(result)
                if (!result || result?.length === 0) {
                    setLoadingState('No files found')
                }
            })
            .catch(error => {
                console.log(error);
                setLoadingState('No files found')
            });
    }, [])

    return (
        <section id="yourAudioFiles">
            <br />
            <div className="section-title">
                <h4>All Audio Files</h4>
            </div>
            <div className="container" align="center">
                {items?.length > 0 ?
                    items.map((x) => <AudioFileItem key={x.id} item={x} />)
                    : <p>{loadingState}</p>}
            </div>
        </section>
    );
};
