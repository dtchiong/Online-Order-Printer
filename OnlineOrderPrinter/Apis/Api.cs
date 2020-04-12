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
            } else {
                Debug.WriteLine($"Failed to Authenticate - {response.StatusCode}");
            }

            return new AuthResponse() {
                User = user,
                StatusCode = response.StatusCode
            };
        }

        public static async Task<FetchRestaurantResponse> FetchRestaurant(string restaurantId, string bearerToken) {
            ConfigureHttpClient(bearerToken);

            HttpResponseMessage response = await client.GetAsync($"api/v1/restaurants/{restaurantId}");
            Restaurant restaurant = null;
            if (response.IsSuccessStatusCode) {
                restaurant = JsonConvert.DeserializeObject<Restaurant>(await response.Content.ReadAsStringAsync(), jsonSerializerSettings);
            } else {
                Debug.WriteLine($"Failed to FetchRestaurant - {response.StatusCode}");
            }

            return new FetchRestaurantResponse() {
                Restaurant = restaurant,
                StatusCode = response.StatusCode
            };
        }

        public static async Task<FetchEventsResponse> FetchEvents(
            string restaurantId,
            string bearerToken,
            string startEventId,
            DateTime? startTime,
            DateTime? endTime) {

            ConfigureHttpClient(bearerToken);

            string query = BuildQuery(new (string, string)[] {
                ("start_event_id", startEventId),
                ("start_time", startTime.ToString()),
                ("end_time", endTime.ToString())
            });

            HttpResponseMessage response = await client.GetAsync($"api/v1/restaurants/{restaurantId}/events{query}");
            Event[] events = null;
            if (response.IsSuccessStatusCode) {
                events = JsonConvert.DeserializeObject<Event[]>(await response.Content.ReadAsStringAsync(), jsonSerializerSettings);
            } else {
                Debug.WriteLine($"Failed to FetchEvents - {response.StatusCode}");
            }

            return new FetchEventsResponse() {
                Events = events,
                StatusCode = response.StatusCode
            };
        }

        public static async Task<FetchEventResponse> FetchEvent(string restaurantId, string eventId, string bearerToken) {
            ConfigureHttpClient(bearerToken);

            HttpResponseMessage response = await client.GetAsync($"api/v1/restaurants/{restaurantId}/events/{eventId}");
            Event @event = null;
            if (response.IsSuccessStatusCode) {
                @event = JsonConvert.DeserializeObject<Event>(await response.Content.ReadAsStringAsync(), jsonSerializerSettings);
            } else {
                Debug.WriteLine($"Failed to FetchEvent - {response.StatusCode}");
            }

            return new FetchEventResponse {
                Event = @event,
                StatusCode = response.StatusCode
            };
        }

        public static async Task<FetchOrderResponse> FetchOrder(string restaurantId, string orderId, string bearerToken) {
            ConfigureHttpClient(bearerToken);

            Order order = null;
            HttpResponseMessage response = await client.GetAsync($"api/v1/restaurants/{restaurantId}/orders/{orderId}");
            if (response.IsSuccessStatusCode) {
                order = JsonConvert.DeserializeObject<Order>(await response.Content.ReadAsStringAsync(), jsonSerializerSettings);
            } else {
                Debug.WriteLine($"Failed to FetchOrder - {response.StatusCode}");
            }

            return new FetchOrderResponse {
                Order = order,
                StatusCode = response.StatusCode
            };
        }

        public static async Task<SyncOrderPrintedResponse> SyncOrderPrinted(string restaurantId, string orderId, string bearerToken) {
            ConfigureHttpClient(bearerToken);

            HttpResponseMessage response = await client.PostAsync($"api/v1/restaurants/{restaurantId}/orders/{orderId}/print", null);
            if (!response.IsSuccessStatusCode) {
                Debug.WriteLine($"Failed to SyncOrderPrinted - {response.StatusCode}");
            }

            return new SyncOrderPrintedResponse() {
                StatusCode = response.StatusCode
            };
        }

        private static string BuildQuery((string name, string val)[] paramList) {
            StringBuilder builder = new StringBuilder("?");
            bool appended = false;
            foreach ((string name, string val) in paramList) {
                if (!string.IsNullOrEmpty(val)) {
                    if (appended) {
                        builder.Append("&");
                    }
                    builder.Append($"{name}={val}");
                    appended = true;
                }
            }
            return appended ? builder.ToString() : "";
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
                if (!client.DefaultRequestHeaders.Contains("Authorization")) {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
                }
            } else {
                client.DefaultRequestHeaders.Remove("Authorization");
            }
        }
    }
}

