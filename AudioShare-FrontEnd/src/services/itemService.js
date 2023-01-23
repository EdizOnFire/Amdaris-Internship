const baseUrl = "https://localhost:5094/audio-share";

export const getAll = () => {
    try {
        return fetch(baseUrl + "/audio-files")
            .then(response => response.json())
    } catch (error) {
        return error;
    }
};

export const getOne = (id) => {
    try {
        return fetch(baseUrl + "/audio-files/" + id)
            .then(response => response.json())
    } catch (error) {
        return error;
    }
};

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
        .catch(error => { return error; });
};

export const edit = (accessToken, id, itemData) => {
    const headers = new Headers();
    const bearer = `Bearer ${accessToken}`;
    headers.append("Authorization", bearer);
    headers.append("Content-Type", "application/json")

    const options = {
        method: 'PUT',
        headers: headers,
        body: JSON.stringify(itemData)
    }

    return fetch(baseUrl + "/audio-files/update/" + id, options)
        .catch(error => { return error; });
};

export const download = (itemPath) => {
    try {
        return fetch(itemPath)
            .then((response) => response.blob())
    } catch (error) {
        return error;
    }
};

export const remove = (accessToken, id, fileName) => {
    try {
        const headers = new Headers();
        const bearer = `Bearer ${accessToken}`;
        headers.append("Authorization", bearer);

        const options = {
            method: 'DELETE',
            headers: headers
        }

        fetch(baseUrl + "/audio-files/delete/" + id, options)
        fetch(baseUrl + "/delete/" + fileName, options)

        return;
    } catch (e) {
        return e;
    }
};