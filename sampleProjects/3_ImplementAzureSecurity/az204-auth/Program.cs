
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace AzAuth
{
    public class Program
    {
        private const string _clientId = "717ee22e-2ce4-4b29-8a53-28a83993be21"; //can be found in overview pane on portal
        private const string _tenantId = "5e072a26-3d22-443d-865f-9dd96b833826";//can be found in overview pane on portal

        public static async Task Main(string[] args)
        {
            var app = PublicClientApplicationBuilder
            .Create(_clientId)
            .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
            .WithRedirectUri("http://localhost")
            .Build();

            string[] scopes = { "user.read" }; //created when the application is registered to AAD in the portal

            AuthenticationResult result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

            Console.WriteLine($"Token:\t{result.AccessToken}");
        }
    }
}
