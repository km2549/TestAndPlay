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
                    "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IjJLVmN1enFBaWRPTHFXU2FvbDd3Z0ZSR0NZbyIsImtpZCI6IjJLVmN1enFBaWRPTHFXU2FvbDd3Z0ZSR0NZbyJ9.eyJhdWQiOiJodHRwczovL2dyYXBoLndpbmRvd3MubmV0IiwiaXNzIjoiaHR0cHM6Ly9zdHMud2luZG93cy5uZXQvZTVjNTRhZWMtMTU0Yy00ZDI5LWI5MGItY2QwNDIzY2Q0NWM5LyIsImlhdCI6MTUwODUzMzgzNiwibmJmIjoxNTA4NTMzODM2LCJleHAiOjE1MDg1Mzc3MzYsImFjciI6IjEiLCJhaW8iOiJZMk5nWUlncWUzb21vamRjZkhyNHRJN3lSWm8zTjltYmYwNFJmaDlXM005eDl0LzlUY2NCIiwiYW1yIjpbInB3ZCJdLCJhcHBpZCI6ImNiZTY5MTFiLTE4NWUtNDAyYi04ZGE1LWRlMzJjOWU4NDNjNyIsImFwcGlkYWNyIjoiMSIsImZhbWlseV9uYW1lIjoiRG9lIiwiZ2l2ZW5fbmFtZSI6IkpvbiIsImlwYWRkciI6IjE2Ny4yMjAuMC4zNCIsIm5hbWUiOiJKb24gRG9lIiwib2lkIjoiNWY0MDZlNjQtODZjOC00OTk3LWFjNzUtNzQyNDU4ZTQwYWE5IiwicHVpZCI6IjEwMDM3RkZFQTQxRERCOUEiLCJzY3AiOiJDYWxlbmRhcnMuUmVhZCBEaXJlY3RvcnkuUmVhZFdyaXRlLkFsbCBHcm91cC5SZWFkV3JpdGUuQWxsIFVzZXIuUmVhZCIsInN1YiI6IkxON3k0MDdKS3pQdE1VblI5dGprTTZ2bmphS3ltNTM1eVI4V3BJTVp1OVUiLCJ0aWQiOiJlNWM1NGFlYy0xNTRjLTRkMjktYjkwYi1jZDA0MjNjZDQ1YzkiLCJ1bmlxdWVfbmFtZSI6ImFkbWluQHRlc3RkcHhmYXVsdGluamVjdGlvbi5vbm1pY3Jvc29mdC5jb20iLCJ1cG4iOiJhZG1pbkB0ZXN0ZHB4ZmF1bHRpbmplY3Rpb24ub25taWNyb3NvZnQuY29tIiwidXRpIjoiWHVjSzIwZnpWa09wRVlOY0IxSU5BQSIsInZlciI6IjEuMCJ9.GCaxm-5Asvxoefd-gOiqtPpRHhPSoSrQr4f16j0x03K4C8r83ReJtWevjXXpYJ4NT78qUPyDdf4aQls2SxtWSktCBxe0VM9BzkRf1I-s0HQVEzG5cBqLVrkYPFjAJJV7gMkNkFQaoS9w5afJLbKd2T8Rt8XpNysd8vstEWmanlOdGRdOuf7yPkcbLnRbgdhb03OMBrLepydVDvPosU5BANIDYh66ThXKHc5poQR4BPHCjj_VHQ3-C2XRu-gU1JafGY8TXt5ZeAmhrQglim6QWhTnuUyyNwpHZyeiIkSMP8R0ToZF3N4sc6ibxQ9SiUnhuzT_wEa30iq76JyiPvwLPQ");
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
                "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IjJLVmN1enFBaWRPTHFXU2FvbDd3Z0ZSR0NZbyIsImtpZCI6IjJLVmN1enFBaWRPTHFXU2FvbDd3Z0ZSR0NZbyJ9.eyJhdWQiOiJodHRwczovL2dyYXBoLndpbmRvd3MubmV0IiwiaXNzIjoiaHR0cHM6Ly9zdHMud2luZG93cy5uZXQvZTVjNTRhZWMtMTU0Yy00ZDI5LWI5MGItY2QwNDIzY2Q0NWM5LyIsImlhdCI6MTUwODczMTczNCwibmJmIjoxNTA4NzMxNzM0LCJleHAiOjE1MDg3MzU2MzQsImFjciI6IjEiLCJhaW8iOiJZMk5nWUtpMnpqVzVITWs1ZTI3SFlkZllSM0krbDNsTWIyNzJZdDRUZUdHdEV1LzVwVXdBIiwiYW1yIjpbInB3ZCJdLCJhcHBpZCI6ImNiZTY5MTFiLTE4NWUtNDAyYi04ZGE1LWRlMzJjOWU4NDNjNyIsImFwcGlkYWNyIjoiMSIsImZhbWlseV9uYW1lIjoiRG9lIiwiZ2l2ZW5fbmFtZSI6IkpvbiIsImlwYWRkciI6IjE2Ny4yMjAuMS4zNCIsIm5hbWUiOiJKb24gRG9lIiwib2lkIjoiNWY0MDZlNjQtODZjOC00OTk3LWFjNzUtNzQyNDU4ZTQwYWE5IiwicHVpZCI6IjEwMDM3RkZFQTQxRERCOUEiLCJzY3AiOiJDYWxlbmRhcnMuUmVhZCBEaXJlY3RvcnkuUmVhZFdyaXRlLkFsbCBHcm91cC5SZWFkV3JpdGUuQWxsIFVzZXIuUmVhZCIsInN1YiI6IkxON3k0MDdKS3pQdE1VblI5dGprTTZ2bmphS3ltNTM1eVI4V3BJTVp1OVUiLCJ0aWQiOiJlNWM1NGFlYy0xNTRjLTRkMjktYjkwYi1jZDA0MjNjZDQ1YzkiLCJ1bmlxdWVfbmFtZSI6ImFkbWluQHRlc3RkcHhmYXVsdGluamVjdGlvbi5vbm1pY3Jvc29mdC5jb20iLCJ1cG4iOiJhZG1pbkB0ZXN0ZHB4ZmF1bHRpbmplY3Rpb24ub25taWNyb3NvZnQuY29tIiwidXRpIjoiT1c3UEdyYnVCRU9hV2FQMEVBc01BQSIsInZlciI6IjEuMCJ9.nqsf4bDvNrdeltK1eJt34XEE88oCcBEqdWQLCULB77otXxsTVh9EO9l5zwAYbVl51CPYW37sXyOQMWAoJjSWQiD1aEVW67wk_WJUhAgRcxfdksCgym63E_k2rU5YJu7a80EmZXTwWJDkLLvJYt-2QOGsuUVvRW2F7YyNi0-WNEt6jEQV5wz07MgHdLfzE4CFcsciynGoA29FrRsCpzE-2Bmnb_OHcr4shJnxdw-pWKEx0BJ3BT-dJHhxJ6ST97Q6acIm1FI3JphyL3Frm3acN9e0NkbT1lqHvtNT2ewXtQWWXK_huBAZbFczUH32oewopUCGi0R-4fxWIV-J5eWhqg");

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
                "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IjJLVmN1enFBaWRPTHFXU2FvbDd3Z0ZSR0NZbyIsImtpZCI6IjJLVmN1enFBaWRPTHFXU2FvbDd3Z0ZSR0NZbyJ9.eyJhdWQiOiJodHRwczovL2dyYXBoLndpbmRvd3MubmV0IiwiaXNzIjoiaHR0cHM6Ly9zdHMud2luZG93cy5uZXQvZTVjNTRhZWMtMTU0Yy00ZDI5LWI5MGItY2QwNDIzY2Q0NWM5LyIsImlhdCI6MTUwODczMTczNCwibmJmIjoxNTA4NzMxNzM0LCJleHAiOjE1MDg3MzU2MzQsImFjciI6IjEiLCJhaW8iOiJZMk5nWUtpMnpqVzVITWs1ZTI3SFlkZllSM0krbDNsTWIyNzJZdDRUZUdHdEV1LzVwVXdBIiwiYW1yIjpbInB3ZCJdLCJhcHBpZCI6ImNiZTY5MTFiLTE4NWUtNDAyYi04ZGE1LWRlMzJjOWU4NDNjNyIsImFwcGlkYWNyIjoiMSIsImZhbWlseV9uYW1lIjoiRG9lIiwiZ2l2ZW5fbmFtZSI6IkpvbiIsImlwYWRkciI6IjE2Ny4yMjAuMS4zNCIsIm5hbWUiOiJKb24gRG9lIiwib2lkIjoiNWY0MDZlNjQtODZjOC00OTk3LWFjNzUtNzQyNDU4ZTQwYWE5IiwicHVpZCI6IjEwMDM3RkZFQTQxRERCOUEiLCJzY3AiOiJDYWxlbmRhcnMuUmVhZCBEaXJlY3RvcnkuUmVhZFdyaXRlLkFsbCBHcm91cC5SZWFkV3JpdGUuQWxsIFVzZXIuUmVhZCIsInN1YiI6IkxON3k0MDdKS3pQdE1VblI5dGprTTZ2bmphS3ltNTM1eVI4V3BJTVp1OVUiLCJ0aWQiOiJlNWM1NGFlYy0xNTRjLTRkMjktYjkwYi1jZDA0MjNjZDQ1YzkiLCJ1bmlxdWVfbmFtZSI6ImFkbWluQHRlc3RkcHhmYXVsdGluamVjdGlvbi5vbm1pY3Jvc29mdC5jb20iLCJ1cG4iOiJhZG1pbkB0ZXN0ZHB4ZmF1bHRpbmplY3Rpb24ub25taWNyb3NvZnQuY29tIiwidXRpIjoiT1c3UEdyYnVCRU9hV2FQMEVBc01BQSIsInZlciI6IjEuMCJ9.nqsf4bDvNrdeltK1eJt34XEE88oCcBEqdWQLCULB77otXxsTVh9EO9l5zwAYbVl51CPYW37sXyOQMWAoJjSWQiD1aEVW67wk_WJUhAgRcxfdksCgym63E_k2rU5YJu7a80EmZXTwWJDkLLvJYt-2QOGsuUVvRW2F7YyNi0-WNEt6jEQV5wz07MgHdLfzE4CFcsciynGoA29FrRsCpzE-2Bmnb_OHcr4shJnxdw-pWKEx0BJ3BT-dJHhxJ6ST97Q6acIm1FI3JphyL3Frm3acN9e0NkbT1lqHvtNT2ewXtQWWXK_huBAZbFczUH32oewopUCGi0R-4fxWIV-J5eWhqg");

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
                "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IjJLVmN1enFBaWRPTHFXU2FvbDd3Z0ZSR0NZbyIsImtpZCI6IjJLVmN1enFBaWRPTHFXU2FvbDd3Z0ZSR0NZbyJ9.eyJhdWQiOiJodHRwczovL2dyYXBoLndpbmRvd3MubmV0IiwiaXNzIjoiaHR0cHM6Ly9zdHMud2luZG93cy5uZXQvZTVjNTRhZWMtMTU0Yy00ZDI5LWI5MGItY2QwNDIzY2Q0NWM5LyIsImlhdCI6MTUwODczMTczNCwibmJmIjoxNTA4NzMxNzM0LCJleHAiOjE1MDg3MzU2MzQsImFjciI6IjEiLCJhaW8iOiJZMk5nWUtpMnpqVzVITWs1ZTI3SFlkZllSM0krbDNsTWIyNzJZdDRUZUdHdEV1LzVwVXdBIiwiYW1yIjpbInB3ZCJdLCJhcHBpZCI6ImNiZTY5MTFiLTE4NWUtNDAyYi04ZGE1LWRlMzJjOWU4NDNjNyIsImFwcGlkYWNyIjoiMSIsImZhbWlseV9uYW1lIjoiRG9lIiwiZ2l2ZW5fbmFtZSI6IkpvbiIsImlwYWRkciI6IjE2Ny4yMjAuMS4zNCIsIm5hbWUiOiJKb24gRG9lIiwib2lkIjoiNWY0MDZlNjQtODZjOC00OTk3LWFjNzUtNzQyNDU4ZTQwYWE5IiwicHVpZCI6IjEwMDM3RkZFQTQxRERCOUEiLCJzY3AiOiJDYWxlbmRhcnMuUmVhZCBEaXJlY3RvcnkuUmVhZFdyaXRlLkFsbCBHcm91cC5SZWFkV3JpdGUuQWxsIFVzZXIuUmVhZCIsInN1YiI6IkxON3k0MDdKS3pQdE1VblI5dGprTTZ2bmphS3ltNTM1eVI4V3BJTVp1OVUiLCJ0aWQiOiJlNWM1NGFlYy0xNTRjLTRkMjktYjkwYi1jZDA0MjNjZDQ1YzkiLCJ1bmlxdWVfbmFtZSI6ImFkbWluQHRlc3RkcHhmYXVsdGluamVjdGlvbi5vbm1pY3Jvc29mdC5jb20iLCJ1cG4iOiJhZG1pbkB0ZXN0ZHB4ZmF1bHRpbmplY3Rpb24ub25taWNyb3NvZnQuY29tIiwidXRpIjoiT1c3UEdyYnVCRU9hV2FQMEVBc01BQSIsInZlciI6IjEuMCJ9.nqsf4bDvNrdeltK1eJt34XEE88oCcBEqdWQLCULB77otXxsTVh9EO9l5zwAYbVl51CPYW37sXyOQMWAoJjSWQiD1aEVW67wk_WJUhAgRcxfdksCgym63E_k2rU5YJu7a80EmZXTwWJDkLLvJYt-2QOGsuUVvRW2F7YyNi0-WNEt6jEQV5wz07MgHdLfzE4CFcsciynGoA29FrRsCpzE-2Bmnb_OHcr4shJnxdw-pWKEx0BJ3BT-dJHhxJ6ST97Q6acIm1FI3JphyL3Frm3acN9e0NkbT1lqHvtNT2ewXtQWWXK_huBAZbFczUH32oewopUCGi0R-4fxWIV-J5eWhqg");

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
                    "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IjJLVmN1enFBaWRPTHFXU2FvbDd3Z0ZSR0NZbyIsImtpZCI6IjJLVmN1enFBaWRPTHFXU2FvbDd3Z0ZSR0NZbyJ9.eyJhdWQiOiJodHRwczovL2dyYXBoLndpbmRvd3MubmV0IiwiaXNzIjoiaHR0cHM6Ly9zdHMud2luZG93cy5uZXQvZTVjNTRhZWMtMTU0Yy00ZDI5LWI5MGItY2QwNDIzY2Q0NWM5LyIsImlhdCI6MTUwODczMTczNCwibmJmIjoxNTA4NzMxNzM0LCJleHAiOjE1MDg3MzU2MzQsImFjciI6IjEiLCJhaW8iOiJZMk5nWUtpMnpqVzVITWs1ZTI3SFlkZllSM0krbDNsTWIyNzJZdDRUZUdHdEV1LzVwVXdBIiwiYW1yIjpbInB3ZCJdLCJhcHBpZCI6ImNiZTY5MTFiLTE4NWUtNDAyYi04ZGE1LWRlMzJjOWU4NDNjNyIsImFwcGlkYWNyIjoiMSIsImZhbWlseV9uYW1lIjoiRG9lIiwiZ2l2ZW5fbmFtZSI6IkpvbiIsImlwYWRkciI6IjE2Ny4yMjAuMS4zNCIsIm5hbWUiOiJKb24gRG9lIiwib2lkIjoiNWY0MDZlNjQtODZjOC00OTk3LWFjNzUtNzQyNDU4ZTQwYWE5IiwicHVpZCI6IjEwMDM3RkZFQTQxRERCOUEiLCJzY3AiOiJDYWxlbmRhcnMuUmVhZCBEaXJlY3RvcnkuUmVhZFdyaXRlLkFsbCBHcm91cC5SZWFkV3JpdGUuQWxsIFVzZXIuUmVhZCIsInN1YiI6IkxON3k0MDdKS3pQdE1VblI5dGprTTZ2bmphS3ltNTM1eVI4V3BJTVp1OVUiLCJ0aWQiOiJlNWM1NGFlYy0xNTRjLTRkMjktYjkwYi1jZDA0MjNjZDQ1YzkiLCJ1bmlxdWVfbmFtZSI6ImFkbWluQHRlc3RkcHhmYXVsdGluamVjdGlvbi5vbm1pY3Jvc29mdC5jb20iLCJ1cG4iOiJhZG1pbkB0ZXN0ZHB4ZmF1bHRpbmplY3Rpb24ub25taWNyb3NvZnQuY29tIiwidXRpIjoiT1c3UEdyYnVCRU9hV2FQMEVBc01BQSIsInZlciI6IjEuMCJ9.nqsf4bDvNrdeltK1eJt34XEE88oCcBEqdWQLCULB77otXxsTVh9EO9l5zwAYbVl51CPYW37sXyOQMWAoJjSWQiD1aEVW67wk_WJUhAgRcxfdksCgym63E_k2rU5YJu7a80EmZXTwWJDkLLvJYt-2QOGsuUVvRW2F7YyNi0-WNEt6jEQV5wz07MgHdLfzE4CFcsciynGoA29FrRsCpzE-2Bmnb_OHcr4shJnxdw-pWKEx0BJ3BT-dJHhxJ6ST97Q6acIm1FI3JphyL3Frm3acN9e0NkbT1lqHvtNT2ewXtQWWXK_huBAZbFczUH32oewopUCGi0R-4fxWIV-J5eWhqg");

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