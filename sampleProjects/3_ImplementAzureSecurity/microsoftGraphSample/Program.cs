using System;
using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Identity.Client;

namespace MicrosoftGraphSample{
    public class Program{
        public static void Main(string[] args){
            Console.WriteLine("Howdi pop os");

            IPublicClientApplication publicClientApplication = PublicClientApplicationBuilder.Create("").Build();

            var tentantId = "common";
            var clientId = "clientId";

            var options = new TokenCredentialOptions{
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
            };

            Func<DeviceCodeInfo,CancellationToken, Task> callback = (code, cancellation)=>{
                Console.WriteLine(code.Message);
    return Task.FromResult(0);
            };

            DeviceCodeCredential credential = new DeviceCodeCredential(callback, tentantId, clientId, options);

            var graphClient = new GraphServiceClient(credential);            

        }
    }
}