using Azure;
using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace az204_blob
{
    public class BlobProperties
    {
        /// <summary>
        /// Retrieves the system properties for a container
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public static async Task ReadContainerPropertiesAsync(BlobContainerClient container)
        {
            try
            {
                // Fetch some container properties and write out their values.
                var properties = await container.GetPropertiesAsync();
                Console.WriteLine($"Properties for container {container.Uri}");
                Console.WriteLine($"Public access level: {properties.Value.PublicAccess}");
                Console.WriteLine($"Last modified time in UTC: {properties.Value.LastModified}");
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine($"HTTP error code {e.Status}: {e.ErrorCode}");
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }


        /// <summary>
        /// Sets user defined meta data
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public static async Task AddContainerMetadataAsync(BlobContainerClient container)
        {
            try
            {
                IDictionary<string, string> metadata =
                   new Dictionary<string, string>();

                // Add some metadata to the container.
                metadata.Add("docType", "textDocuments");
                metadata.Add("category", "guidance");

                // Set the container's metadata.
                await container.SetMetadataAsync(metadata);
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine($"HTTP error code {e.Status}: {e.ErrorCode}");
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }


        /// <summary>
        /// Retrieves user defined meta data
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public static async Task ReadContainerMetadataAsync(BlobContainerClient container)
        {
            try
            {
                var properties = await container.GetPropertiesAsync();

                // Enumerate the container's metadata.
                Console.WriteLine("Container metadata:");
                foreach (var metadataItem in properties.Value.Metadata)
                {
                    Console.WriteLine($"\tKey: {metadataItem.Key}");
                    Console.WriteLine($"\tValue: {metadataItem.Value}");
                }
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine($"HTTP error code {e.Status}: {e.ErrorCode}");
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
