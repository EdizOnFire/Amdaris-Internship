const baseUrl = "https://localhost:5094/audio-share";

export const getAll = () => {
    return fetch(baseUrl + "/audio-files")
        .then(response => response.json())
        .catch(error => console.log(error))
}

export const upload = (accessToken, itemData, title, description, user) => {
    const headers = new Headers();
    const bearer = `Bearer ${accessToken}`;
    headers.append("Authorization", bearer);

    const options = {
        method: 'POST',
        headers: headers,
        body: itemData
    }

    return fetch(`${baseUrl}/upload?title=${title}&description=${description}&user=${user}`, options)
};

export const download = (itemPath) => {
    return fetch(itemPath)
        .then((response) => response.blob())
        .catch(error => console.log(error))
}
