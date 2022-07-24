
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using az204_blob.Models;

namespace az204_blob
{
    public class Program
    {
        public static void Main()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            AppSettings settings = config.Get<AppSettings>();

            Console.WriteLine("Azure Blob Storage exercise\n");

            // Run the examples asynchronously, wait for the results before proceeding
            ProcessAsync(settings).GetAwaiter().GetResult();

            Console.WriteLine("Press enter to exit the sample application.");
            Console.ReadLine();
        }


        private static async Task ProcessAsync(AppSettings settings)
        {
            // Copy the connection string from the portal in the variable below.
            string storageConnectionString = settings.ConnectionStrings.GetValueOrDefault("BlobStorage");

            // Create a client that can authenticate with a connection string
            BlobServiceClient blobServiceClient = new BlobServiceClient(storageConnectionString);
            BlobContainerClient containerCient = await BlobCrud.CreateContainer(blobServiceClient);

            string localPath = "./";
            string fileName = "testFile.txt";
            string localFile = Path.Combine(localPath, fileName);

            //await File.WriteAllTextAsync(localPath, "Hello, World!");
            // EXAMPLE CODE STARTS BELOW HERE

            BlobClient blobClient = containerCient.GetBlobClient(fileName);

            await BlobCrud.UploadBlob(blobClient, fileName);

            await BlobCrud.ListBlobs(containerCient);

            await BlobCrud.DownloadBlobs(blobClient, fileName.Replace(".txt", "DOWNLOADED.txt"));

            await BlobCrud.DeleteContainer(containerCient);
        }
    }
}