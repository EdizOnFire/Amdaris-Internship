import { useLoaderData } from "react-router-dom"
import AudioFileItem from "../AudioFileItem/AudioFileItem"
import * as itemService from "../../services/itemService";

const AudioFiles = () => {
    const items = useLoaderData();

    return (
        <div className="container" align="center">
            {items?.length > 0 ?
                items.map((x) => <AudioFileItem key={x.id} item={x} />)
                : <p>No files found</p>}
        </div>
    )
}

export const audioFilesLoader = async () => {
    try {
        const result = await itemService.getAll()
        return result.data;
    } catch (error) {
        console.log(error);
        return error;
    }
};

export default AudioFiles;