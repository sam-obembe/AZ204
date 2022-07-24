using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace az204_blob
{
    public class BlobCrud
    {
        public static async Task<BlobContainerClient> CreateContainer(BlobServiceClient blobServiceClient)
        {
            //Create a unique name for the container
            string containerName = "wtblob" + Guid.NewGuid().ToString();

            // Create the container and return a container client object
            BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);
            Console.WriteLine("A container named '" + containerName + "' has been created. " +
                "\nTake a minute and verify in the portal." +
                "\nNext a file will be created and uploaded to the container.");
            Console.WriteLine("Press 'Enter' to continue.");
            Console.ReadLine();

            return containerClient;
        }

        public static async Task UploadBlob(BlobClient blobClient, string filePath)
        {
            Console.WriteLine("Uploading to Blob storage as blob:\n\t {0}\n", blobClient.Uri);

            using FileStream uploadFileStream = File.OpenRead(filePath);
            await blobClient.UploadAsync(uploadFileStream, true);
            uploadFileStream.Close();

            Console.WriteLine("\nThe file was uploaded. We'll verify by listing" +
        " the blobs next.");
            Console.WriteLine("Press 'Enter' to continue.");
            Console.ReadLine();
        }

        public static async Task ListBlobs(BlobContainerClient blobContainerClient)
        {
            Console.WriteLine("Listing blobs...");
            var blobs = blobContainerClient.GetBlobsAsync();

            await foreach (var blob in blobs)
            {
                Console.WriteLine("\t" + blob.Name);
            }

            Console.WriteLine("\nYou can also verify by looking inside the " +
        "container in the portal." +
        "\nNext the blob will be downloaded with an altered file name.");
            Console.WriteLine("Press 'Enter' to continue.");
            Console.ReadLine();

        }

        public static async Task DownloadBlobs(BlobClient blobClient, string downloadFilePath)
        {
            Console.WriteLine("\nDownloading blob to\n\t{0}\n", downloadFilePath);

            BlobDownloadInfo download = await blobClient.DownloadAsync();

            using (FileStream downloadFileStream = File.OpenWrite(downloadFilePath))
            {
                await download.Content.CopyToAsync(downloadFileStream);
                downloadFileStream.Close();
            }
            Console.WriteLine("\nLocate the local file to verify it was downloaded.");
            Console.WriteLine("The next step is to delete the container and local files.");
            Console.WriteLine("Press 'Enter' to continue.");
            Console.ReadLine();
        }

        public static async Task DeleteContainer(BlobContainerClient containerClient)
        {
            Console.WriteLine("\n\nDeleting blob container...");
            await containerClient.DeleteAsync();

            Console.WriteLine("Finished cleaning up.");
        }
    }
}
