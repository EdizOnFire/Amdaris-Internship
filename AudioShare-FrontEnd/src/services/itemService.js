import axios from "axios";

const baseUrl = "https://localhost:5094/audio-share";

export const getAll = () => axios.get(baseUrl + "/audio-files");

export const upload = (itemData) => axios.post(baseUrl + "/upload", itemData);

export const download = (itemPath) => fetch(itemPath);
