using Domain.Interfaces;
using Domain.JSON;
using Domain.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;

namespace Domain.Services
{
    public class IPStackHttpClient : IIPStackHttpClient
    {
        //private readonly HttpClient _ipstack;
        private readonly HttpClient _httpClient = new();

        public IPStackHttpClient()
        {
        }

        public async Task<IPDetails> GetDetailsFromIPStack(string ip)
        {
            IPDetails details = null;
            try
            {
                var http_result = await _httpClient.GetAsync("http://api.ipstack.com/" + ip + "?access_key=" + Environment.GetEnvironmentVariable("IPSTACK_KEY")); // 4f2196bd90bd5a597053967a91272e68
                if (http_result.StatusCode != HttpStatusCode.OK)
                {
                    Console.WriteLine($"Request for Ip: {ip} failed with Status Code: {http_result.StatusCode}");
                    throw new Exception($"Request for Ip: {ip} failed with Status Code: {http_result.StatusCode}");
                }
                var body = await http_result.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                var details_json = JsonConvert.DeserializeObject<IPDetailsJSON>(body);
                if(details_json.success == false)
                {
                    throw new Exception($"IP Stack could not resoleve IP: {ip}");
                }
                details = IPDetails.Create(ip, details_json.City, details_json.Country, details_json.Continent, details_json.Latitude, details_json.Longitude);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("\n Http Exception Caught!");
                Console.WriteLine("Message :{0} ", ex.Message);
            }

            return details;
        }



    }
}
