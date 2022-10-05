using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;
using System.Security.Policy;
using static System.Net.WebRequestMethods;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;

namespace ZapiCSharp
{
    public class program
    {
        static void Main(string[] arg)
        {
            string cycleId = "94608786-bec3-4e5c-bc96-7fb00f60071a";
            int projectId = 10002;
            int versionId = -1;
            int issueId = 10027;
            string executionId = "0e8abaaa-6993-49f4-89e3-03b0fb301075";
            string action_Api = "execution/" + executionId;
            string parametros = "{'status':{'id':1},'projectId':" + projectId + ",'issueId':" + issueId + ",'cycleId':'" + cycleId + "','versionId':" + versionId + "}";
            ZapiCSharp.program.RunPutAsync("/public/rest/api/1.0/" + action_Api, "", parametros).Wait();
        }

        public static async Task RunGetAsync(string RELATIVE_PATH, string QUERY_STRING)
        {
            HttpClient client = new HttpClient();


            var SECRET_KEY = "";

            var ACCESS_KEY = "";

            var ACCOUNT_ID = "";

            var BASE_URL = "https://prod-api.zephyr4jiracloud.com/connect";

            var CONTEXT_PATH = "/connect";

            var EXPIRE_TIME = 3600;

            client.BaseAddress = new Uri(BASE_URL);

            var utc0 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var issueTime = DateTime.Now;

            var iat = (long)issueTime.Subtract(utc0).TotalMilliseconds;
            var exp = (long)issueTime.AddMilliseconds(EXPIRE_TIME).Subtract(utc0).TotalMilliseconds;

            var canonical_path = "GET&" + RELATIVE_PATH + "&" + QUERY_STRING;
            var payload = new Dictionary<string, object>()
            {
                {"sub", ACCOUNT_ID },
                {"qsh", getQSH(canonical_path)},
                {"iss", ACCESS_KEY },
                {"iat", iat },
                {"exp", exp }
            };

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            string token = encoder.Encode(payload, SECRET_KEY);
            
            client.DefaultRequestHeaders.ProxyAuthorization = null;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Authorization", "JWT " + token);
            client.DefaultRequestHeaders.Add("zapiAccessKey", ACCESS_KEY);
            client.DefaultRequestHeaders.Add("User-Agent", "ZAPI");

            try
            {
                HttpResponseMessage response = await client.GetAsync(CONTEXT_PATH + RELATIVE_PATH + "?" + QUERY_STRING);

                response.EnsureSuccessStatusCode();

                //write response in console
                Console.WriteLine(response);

                // Deserialize the updated product from the response body.
                string result = await response.Content.ReadAsStringAsync();

                //write Response in console
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public static async Task RunPostAsync(string RELATIVE_PATH, string QUERY_STRING, string Parametros)
        {
            HttpClient client = new HttpClient();


            var SECRET_KEY = "XfuqWAhgHYEFlb95BLqRYjvO0OhazHnrIUCpBZ-5GEs";

            var ACCESS_KEY = "MTI3ZWE3YmUtNzU5Zi0zMGEyLWI3OWItMGFkN2JlNjY2MjVhIDYyZmU5MDM1NTVhMTc5MzIxNTkxZWY2NCBVU0VSX0RFRkFVTFRfTkFNRQ";

            var ACCOUNT_ID = "62fe903555a179321591ef64";

            var BASE_URL = "https://prod-api.zephyr4jiracloud.com/connect";

            var CONTEXT_PATH = "/connect";

            var EXPIRE_TIME = 3600;

            client.BaseAddress = new Uri(BASE_URL);

            var utc0 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var issueTime = DateTime.Now;

            var iat = (long)issueTime.Subtract(utc0).TotalMilliseconds;
            var exp = (long)issueTime.AddMilliseconds(EXPIRE_TIME).Subtract(utc0).TotalMilliseconds;

            var canonical_path = "POST&" + RELATIVE_PATH + "&" + QUERY_STRING;
            var payload = new Dictionary<string, object>()
            {
                {"sub", ACCOUNT_ID },
                {"qsh", getQSH(canonical_path)},
                {"iss", ACCESS_KEY },
                {"iat", iat },
                {"exp", exp }
            };

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            string token = encoder.Encode(payload, SECRET_KEY);

            client.DefaultRequestHeaders.ProxyAuthorization = null;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Authorization", "JWT " + token);
            client.DefaultRequestHeaders.Add("zapiAccessKey", ACCESS_KEY);
            client.DefaultRequestHeaders.Add("User-Agent", "ZAPI");

            try
            {
                dynamic jsonstring = JObject.Parse(Parametros);
                var httpcontent = new StringContent(jsonstring.ToString(), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(CONTEXT_PATH + RELATIVE_PATH + "?" + QUERY_STRING, httpcontent).Result;

             response.EnsureSuccessStatusCode();

                //write response in console
                Console.WriteLine(response);

                // Deserialize the updated product from the response body.
                string result = await response.Content.ReadAsStringAsync();

                //write Response in console
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static async Task RunPutAsync(string RELATIVE_PATH, string QUERY_STRING, string Parametros)
        {
            HttpClient client = new HttpClient();


            var SECRET_KEY = "XfuqWAhgHYEFlb95BLqRYjvO0OhazHnrIUCpBZ-5GEs";

            var ACCESS_KEY = "MTI3ZWE3YmUtNzU5Zi0zMGEyLWI3OWItMGFkN2JlNjY2MjVhIDYyZmU5MDM1NTVhMTc5MzIxNTkxZWY2NCBVU0VSX0RFRkFVTFRfTkFNRQ";

            var ACCOUNT_ID = "62fe903555a179321591ef64";

            var BASE_URL = "https://prod-api.zephyr4jiracloud.com/connect";

            var CONTEXT_PATH = "/connect";

            var EXPIRE_TIME = 3600;

            client.BaseAddress = new Uri(BASE_URL);

            var utc0 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var issueTime = DateTime.Now;

            var iat = (long)issueTime.Subtract(utc0).TotalMilliseconds;
            var exp = (long)issueTime.AddMilliseconds(EXPIRE_TIME).Subtract(utc0).TotalMilliseconds;

            var canonical_path = "PUT&" + RELATIVE_PATH + "&" + QUERY_STRING;
            var payload = new Dictionary<string, object>()
            {
                {"sub", ACCOUNT_ID },
                {"qsh", getQSH(canonical_path)},
                {"iss", ACCESS_KEY },
                {"iat", iat },
                {"exp", exp }
            };

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            string token = encoder.Encode(payload, SECRET_KEY);

            client.DefaultRequestHeaders.ProxyAuthorization = null;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Authorization", "JWT " + token);
            client.DefaultRequestHeaders.Add("zapiAccessKey", ACCESS_KEY);
            client.DefaultRequestHeaders.Add("User-Agent", "ZAPI");

            try
            {
                dynamic jsonstring = JObject.Parse(Parametros);
                var httpcontent = new StringContent(jsonstring.ToString(), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(CONTEXT_PATH + RELATIVE_PATH + "?" + QUERY_STRING, httpcontent).Result;

                response.EnsureSuccessStatusCode();

                //write response in console
                Console.WriteLine(response);

                // Deserialize the updated product from the response body.
                string result = await response.Content.ReadAsStringAsync();

                //write Response in console
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        static string getQSH(string qstring)
        {
            SHA256 crypt = SHA256.Create();
            StringBuilder hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(qstring), 0, Encoding.UTF8.GetByteCount(qstring));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

    }

}


