//using Domain.Interfaces;
using Domain.Models;
using System.Net;
using Newtonsoft.Json;
using Domain.JSON;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace IPScanner.Application
{

    public class IPInfoDetails
    {
        private readonly HttpClient httpClient = new HttpClient();
        private IPDetails ip_details;

        private readonly DataDbContext _context = new();

        public IPInfoDetails()
        {
            //_context = context;
        }

        public async Task<IPDetails> GetDetails(string ip)
        {

            // check if ip is in cache



            // check if ip is in database
            //add to cache
            var ip_details = await _context.Details.SingleOrDefaultAsync(x => x.IP == ip);

            if (ip_details != null)
            {
                return ip_details;
            }

            // get ip details from httpClient
            try
            {
                var http_result = await httpClient.GetAsync("http://api.ipstack.com/" + ip + "?access_key=4f2196bd90bd5a597053967a91272e68");
                if (http_result.StatusCode != HttpStatusCode.OK)
                {
                    Console.WriteLine($"Request for Ip: {ip} failed with Status Code: {http_result.StatusCode}");
                    throw new Exception($"Request for Ip: {ip} failed with Status Code: {http_result.StatusCode}");
                }
                var body = await http_result.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                var details_json = JsonConvert.DeserializeObject<IPDetailsJSON>(body);
                ip_details = IPDetails.Create(ip,details_json.city, details_json.country_name, details_json.continent_name, details_json.latitude, details_json.longitude);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("\n Http Exception Caught!");
                Console.WriteLine("Message :{0} ", ex.Message);
            }



            // store to database and cache
            //add to cache

            if (ip_details != null)
            {
                await _context.Details.AddAsync(ip_details);
                await _context.SaveChangesAsync();
            }


            //return new IPDetails
            //{
            //    City = result.,
            //    Continent = "",

            //};

            return ip_details;
        }
    }


}