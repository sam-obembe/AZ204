namespace blobSDKInteraction
{
    public class Common
    {
        public static BlobServiceClient CreateBlobClientStorageFromSAS(string SASConnectionString)
        {
            BlobServiceClient blobClient;

            try{
                blobClient = new BlobServiceClient(SASConnectionString);
            }
            catch(Exception ex){
                throw;
            }

            return blobClient;

        }
    }
}