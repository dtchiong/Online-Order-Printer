﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OnlineOrderPrinter.Apis.Responses;
using OnlineOrderPrinter.Models;
using OnlineOrderPrinter.State;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Apis {
    class Api {
        static readonly Uri DevApiBaseUri = new Uri("http://192.168.1.3:3000/");
        static readonly Uri ProdApiBaseUri = new Uri("https://www.onlineorderparser.com/");

        static readonly JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings {
            ContractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() }
        };

        // TODO: Maybe separate this instance into it's own class so that we can configure setting the 
        // default headers on class instantiation instead of checking if default headers need to be set on each request. 
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

        public static async Task<AuthorizeActionResponse> AuthorizeAction(
            string restaurantId,
            string bearerToken,
            string username,
            string password,
            UserType userType) {

            ConfigureHttpClient(bearerToken);

            object data = new {
                email = username,
                password,
                minimum_level = JsonConvert.SerializeObject(userType).Replace("\"", "")
            };

            HttpResponseMessage response = await client.PostAsync("api/v1/authorize_action/", CreateByteArrayContent(data));
            if (!response.IsSuccessStatusCode) {
                Debug.WriteLine("Failed to AuthorizeAction");
            }
            return new AuthorizeActionResponse() {
                StatusCode = response.StatusCode
            };
        }

        public static async Task<FetchUserResponse> FetchUser(string userId, string bearerToken) {
            ConfigureHttpClient(bearerToken);

            HttpResponseMessage response = await client.GetAsync($"api/v1/users/{userId}");
            User user = null;
            if (response.IsSuccessStatusCode) {
                user = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync(), jsonSerializerSettings);
            } else {
                Debug.WriteLine($"Failed to FetchUser - {response.StatusCode}");
            }

            return new FetchUserResponse() {
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
            long? startEventId,
            DateTime? startTime,
            DateTime? endTime,
            CancellationToken ct) {

            ConfigureHttpClient(bearerToken);

            string query = BuildQuery(new (string, string)[] {
                ("start_event_id", startEventId.ToString()),
                ("start_time", (startTime != null? startTime.Value.ToUniversalTime().ToString("o") : "")),
                ("end_time", (endTime != null? endTime.Value.ToUniversalTime().ToString("o") : ""))
            });

            HttpResponseMessage response = await client.GetAsync($"api/v1/restaurants/{restaurantId}/events{query}", ct);
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
            return DevApiBaseUri;
#else
            return ProdApiBaseUri;
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
            SetApiKey();
        }

        private static void SetHttpClientBaseProperties() {
            if (client.BaseAddress == null) {
                client.BaseAddress = GetApiBaseUri();
                client.Timeout = TimeSpan.FromMinutes(1);
            }
        }

        private static void SetBearerToken(string bearerToken) {
            if (bearerToken != null) {
                // TODO: There seems to be a bug where the header tries to added even though it already exists. 
                // Might be related to multiple threads reading .Contains(). The bearer token should be set
                // per request, instead of of added to the default request headers.
                try {
                    if (!client.DefaultRequestHeaders.Contains("Authorization")) {
                        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
                    }
                } catch (Exception e) {
                    Debug.WriteLine(e.Message);
                }
            } else {
                client.DefaultRequestHeaders.Remove("Authorization");
            }
        }

        private static void SetApiKey() {
            try {
                if (!client.DefaultRequestHeaders.Contains("Api-Key")) {
                    client.DefaultRequestHeaders.Add("Api-Key", AppState.ApiKey);
                }
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }
        }
    }
}

