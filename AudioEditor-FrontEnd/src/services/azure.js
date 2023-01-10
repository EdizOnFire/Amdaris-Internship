import { BlobServiceClient, StorageSharedKeyCredential } from 'azure-storage';

const AudioStream = ((blobName) => {
    const storageAccountName = 'audioeditor';
    const storageAccountKey = 'DefaultEndpointsProtocol=https;AccountName=audioeditor;AccountKey=QhKgWU7dBpfDwwrA9J7QWAqcuLOpZSWbdOsqTygUUVUEaSaQdNT1iGNecfEg0uR/IKroMygQ4P05+AStghd0yA==;EndpointSuffix=core.windows.net';
    const blobServiceClient = new BlobServiceClient(
        `https://${storageAccountName}.blob.core.windows.net`,
        new StorageSharedKeyCredential(storageAccountName, storageAccountKey)
    );
    const containerName = 'files';
    const containerClient = blobServiceClient.getContainerClient(containerName);
    const blobClient = containerClient.getBlobClient(blobName);

    const audioElement = document.getElementById('audio-element');

    blobClient.download().then((blobResponse) => {
        const stream = blobResponse.readableStreamBody;
        audioElement.src = stream;
    })
});

export default AudioStream;
