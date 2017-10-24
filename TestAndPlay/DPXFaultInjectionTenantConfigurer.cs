using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace TestAndPlay
{
    internal class DpxFaultInjectionTenantConfigurer
    {
        public async Task CreateGroups()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Specify values for the following required parameters
            queryString["api-version"] = "1.6";
            // Specify values for path parameters (shown as {...})
            var uri = "https://graph.windows.net/e5c54aec-154c-4d29-b90b-cd0423cd45c9/groups?" + queryString;

            for (int i = 2; i <= 100; i++)
            {
                Console.WriteLine("starting " + i);
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
                httpRequestMessage.Headers.Add(HttpRequestHeader.Authorization.ToString(),
                    "");
                string requestBody =
                    "{\"displayName\": \"IsMemberOfExploit100_Group" + i +
                    "\",\"mailNickname\": \"ExampleGroup\",\"mailEnabled\": false,\"securityEnabled\": true}";
                httpRequestMessage.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");

                await client.SendAsync(httpRequestMessage);
            }
        }

        public async Task PrintGroups()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Specify values for the following required parameters
            queryString["api-version"] = "1.6";
            // Specify values for path parameters (shown as {...})
            var uri =
                "https://graph.windows.net/e5c54aec-154c-4d29-b90b-cd0423cd45c9/groups?$filter=startswith(displayName,'IsMemberOfExploit100')&" +
                queryString;

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            httpRequestMessage.Headers.Add(HttpRequestHeader.Authorization.ToString(),
                "");

            var response = await client.SendAsync(httpRequestMessage);
            if (response.Content != null)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                RootObject o = JsonConvert.DeserializeObject<RootObject>(responseString);
                Console.WriteLine(o.value.Count);
                foreach (var v in o.value)
                {
                    Console.WriteLine(v.displayName);
                }
            }
        }

        public async Task CreateGroupAndPrintId()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Specify values for the following required parameters
            queryString["api-version"] = "1.6";
            // Specify values for path parameters (shown as {...})
            var uri = "https://graph.windows.net/e5c54aec-154c-4d29-b90b-cd0423cd45c9/groups?" + queryString;

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
            httpRequestMessage.Headers.Add(HttpRequestHeader.Authorization.ToString(),
                "");

            string requestBody =
                "{\"displayName\": \"Example_Group\",\"mailNickname\": \"ExampleGroup\",\"mailEnabled\": false,\"securityEnabled\": true}";
            httpRequestMessage.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            var response = await client.SendAsync(httpRequestMessage);
            if (response.Content != null)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                Value o = JsonConvert.DeserializeObject<Value>(responseString);
                Console.WriteLine(o.objectId);
            }
        }

        public async Task CreateGroupAndAddAsMember()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Specify values for the following required parameters
            queryString["api-version"] = "1.6";
            // Specify values for path parameters (shown as {...})
            var uri = "https://graph.windows.net/e5c54aec-154c-4d29-b90b-cd0423cd45c9/groups?" + queryString;

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
            httpRequestMessage.Headers.Add(HttpRequestHeader.Authorization.ToString(),
                "");

            string requestBody =
                "{\"displayName\": \"Example_Group2\",\"mailNickname\": \"ExampleGroup\",\"mailEnabled\": false,\"securityEnabled\": true}";
            httpRequestMessage.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            var response = await client.SendAsync(httpRequestMessage);
            if (response.Content != null)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                Value o = JsonConvert.DeserializeObject<Value>(responseString);

                uri =
                    "https://graph.windows.net/e5c54aec-154c-4d29-b90b-cd0423cd45c9/groups/4df09cdb-e5b9-4f2f-931b-1c7b589a87d6/$links/members?" +
                    queryString;

                httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
                httpRequestMessage.Headers.Add(HttpRequestHeader.Authorization.ToString(),
                    "");

                requestBody =
                    "{\"url\": \"https://graph.windows.net/e5c54aec-154c-4d29-b90b-cd0423cd45c9/directoryObjects/" +
                    o.objectId + "\"}";
                httpRequestMessage.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");

                await client.SendAsync(httpRequestMessage);
            }
        }

        public async Task CreateForest(int fanOut, int levels)
        {

        }
    }
}