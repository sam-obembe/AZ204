
namespace blobSDKInteraction
{
    public class AppSettings
    {
        public string SourceSASConnectionString{get;set;}
        public string SourceAccountName {get;set;}
        public string SourceContainerName {get;set;}
        public string DestinationSASConnectionString {get;set;}
        public string DestinationAccountName{get;set;}
        public string DestinationContainerName{get;set;}

        public static AppSettings LoadAppSettings(){
            IConfigurationRoot configRoot = new ConfigurationBuilder().AddJsonFile("appsettings.json",false).Build();
            AppSettings appsettings = configRoot.Get<AppSettings>();
            return appsettings;
        }
    }
}