using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OnlineOrderPrinter.Models;
using OnlineOrderPrinter.Apis.Responses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Apis {
    class Api {
        static readonly Uri DEV_API_BASE_URI = new Uri("http://192.168.1.3:3000/");
        static readonly Uri PROD_API_BASE_URI = new Uri("http://production.eba-ckgxeb6t.us-west-1.elasticbeanstalk.com/");

        static readonly JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings {
            ContractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() }
        };

        static readonly HttpClient client = new HttpClient();

        public static async Task<AuthResponse> Authenticate(string email, string password) {
            ConfigureHttpClient();

            object data = new {
                email,
                password
            };

            HttpResponseMessage response = await client.PostAsync("api/v1/auth/", CreateByteArrayContent(data));
            User user = null;
            if (response.IsSuccessStatusCode) {
                user = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync(), jsonSerializerSettings);
            }

            return new AuthResponse() {
                User = user,
                StatusCode = response.StatusCode
            };
        }

        private static Uri GetApiBaseUri() {
#if DEBUG
            return DEV_API_BASE_URI;
#else
            return PROD_API_BASE_URI;
#endif
        }

        private static ByteArrayContent CreateByteArrayContent(object data) {
            var content = JsonConvert.SerializeObject(data);
            var buffer = Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return byteContent;
        }

        private static void ConfigureHttpClient(string bearerToken = null) {
            SetHttpClientBaseProperties();
            SetBearerToken(bearerToken);
        }

        private static void SetHttpClientBaseProperties() {
            if (client.BaseAddress == null) {
                client.BaseAddress = GetApiBaseUri();
                client.Timeout = TimeSpan.FromMinutes(1);
            }
        }

        private static void SetBearerToken(string bearerToken) {
            if (bearerToken != null) {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
            } else {
                client.DefaultRequestHeaders.Remove("Authorization");
            }
        }
    }
}

