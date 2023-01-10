import { useState, useRef } from "react";
import * as itemService from "../../services/itemService";
import LoadingButton from '@mui/lab/LoadingButton';
import SaveIcon from '@mui/icons-material/Save';
import { Button } from '@mui/material';

const AudioFileItem = ({ item }) => {
    const [download, setDownload] = useState("");
    const [loadingState, setLoadingState] = useState(".....");
    const audioRef = useRef(null);

    const onClick = (e) => {
        e.preventDefault();

        setLoadingState("Retrieving...");
        itemService
            .download(item.path)
            .then((response) => response.blob())
            .then((newResponse) => {
                console.log(newResponse);
                const url = URL.createObjectURL(newResponse);
                setDownload(url);
                audioRef.current.src = url;
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
            <Button onClick={onClick} className="downloadButton">
                Request Download
            </Button>
            {download ? (
                <div>
                    <Button href={download} variant="outlined" download={item.fileName}>
                        Download
                    </Button >
                </div>
            ) : (
                <div>
                    <LoadingButton sx={{ cursor: 'default' }} download={item.fileName}>
                        {loadingState}
                    </LoadingButton >
                </div>
            )}
            <div>
                <audio controls ref={audioRef}>
                    <source src={audioRef} />
                </audio>
            </div>
        </article>
    );
};

export default AudioFileItem;
