import { useState } from "react";
import * as itemService from "../../services/itemService";
import { Button } from '@mui/material';

export default function AudioFileItem({ item }) {
    const [download, setDownload] = useState("");
    const [loadingState, setLoadingState] = useState(".....");

    const onClick = (e) => {
        e.preventDefault();

        setLoadingState("Retrieving...");
        itemService
            .download(item.path)
            .then((response) => response.blob())
            .then((newResponse) => {
                const url = URL.createObjectURL(newResponse);
                setDownload(url);
                setLoadingState(".....");
            })
            .catch((error) => {
                console.error(error);
                setLoadingState("Failed");
            });
    };

    return (
        <article className="audioFile">
            <div className="itemName">File name: {item.fileName}</div>
            <div className="itemFormat">Format: {item.format}</div>
            <div>
                <Button onClick={onClick} >
                    Load Audio
                </Button>
            </div>
            {download ? (
                <div>
                    <Button href={download} download={item.fileName}>
                        Download
                    </Button >
                </div>
            ) : (
                <div>
                    {loadingState}
                </div>
            )}
            <div>
                <audio controls src={download} />
            </div>
        </article>
    );
};
