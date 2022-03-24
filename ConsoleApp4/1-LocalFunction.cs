using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LocalFunctionSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = Process();
            task.Wait();
        }

        static async Task Process()
        {
            try
            {
                var result = await getDogService().GetDogFacts(1);
                var dog = JsonConvert.DeserializeObject<Dog>(result); ;
                Console.WriteLine(result);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured");
            }                      

            DogFactsApi getDogService()
            {
                using var serviceScope = getHost().Services.CreateScope();
                var services = serviceScope.ServiceProvider;
                var service = services.GetRequiredService<DogFactsApi>();
                return service;
            }

            IHost getHost() =>
            (
                new HostBuilder()
                    .ConfigureServices((hostContext, services) =>
                    {
                        services.AddHttpClient();
                        services.AddTransient<DogFactsApi>();
                    }).UseConsoleLifetime()).Build();
        }
    }


    public class DogFactsApi
    {
        private IHttpClientFactory _httpFactory { get; set; }
        public DogFactsApi(IHttpClientFactory httpFactory)
        {
            _httpFactory = httpFactory;
        }

        public async Task<string> GetDogFacts(int numberId)
        {
            var client = _httpFactory.CreateClient();
            var response = await client.SendAsync(getRequest());
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return result;

            HttpRequestMessage getRequest()
            {
                var queryString = new Dictionary<string, string>()
                {
                    { "number", numberId.ToString() }
                };
                var requestUri = QueryHelpers.AddQueryString("https://dog-api.kinduff.com/api/facts", queryString);
                var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return request;
            }
        }
    }

    public class Dog
    {
        public List<string> Facts { get; set; }
    }
}
