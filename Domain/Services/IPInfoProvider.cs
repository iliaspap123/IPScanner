using Domain.Interfaces;
using Domain.Models;
using Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Domain.Services
{
    public class IPInfoProvider : IIPInfoProvider
    {
        
        private readonly IMemoryCache _memoryCache;
        private readonly IDataDbContext _context;
        private readonly IIPStackHttpClient _client;

        public IPInfoProvider(IMemoryCache memoryCache, IDataDbContext context, IIPStackHttpClient client)
        {
            _memoryCache = memoryCache;
            _context = context;
            _client = client;
        }

        public async Task<IPDetails?> GetDetails(string ip)
        {
            IPDetails details = null;

            // Try get value from cache
            if(_memoryCache.TryGetValue(ip, out details))
            {
                return details;
            }


            // Try get value from database
            details = await _context.Details.SingleOrDefaultAsync(x => x.IP == ip);
            if(details != null)
            {
                _memoryCache.Set(ip, details, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(60)));
                return details;
            }
            
            // Try get value from IPStack 
            details = await _client.GetDetailsFromIPStack(ip);
            if(details != null)
            {
                _memoryCache.Set(ip, details, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(60)));
                await _context.Details.AddAsync(details);
                await _context.SaveChangesAsync();
                return details;
            }


            return null;
        }
    }
}
