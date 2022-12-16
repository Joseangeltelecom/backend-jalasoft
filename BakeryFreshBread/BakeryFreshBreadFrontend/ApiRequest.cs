using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BakeryFreshBreadFrontend
{
    public class ApiRequest
    {
        static readonly HttpClient client = new HttpClient();
        public static async Task<List<T>> GetList<T>(string path)
        {
            List<T> offices = new List<T>();
            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                offices = JsonSerializer.Deserialize<List<T>>(result, options);
            }
            return offices;
        }

        public static async Task<T> Create<T>(string path, T entity)
        {
            string json = JsonSerializer.Serialize(entity);

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(path, httpContent);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var entityCreated = JsonSerializer.Deserialize<T>(result, options);
                return entityCreated;
            }
            return entity;
        }
    }
}
