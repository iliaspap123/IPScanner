using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public interface IDataDbContext
    {
        public DbSet<IPDetails> Details { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}