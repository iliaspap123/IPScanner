using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace Persistence
{
    public class DataDbContext : DbContext, IDataDbContext
    {

        public DbSet<IPDetails> Details { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //base.OnConfiguring(optionsBuilder);
        //    // docker run -e "ACCEPT_EULA=Y" - e 'SA_PASSWORD=ThisIsIPScannerPa$$w0rd97' - p 1433:1433 - d mcr.microsoft.com / mssql / server:2022 - latest

        //    //var connection_string = "Server=localhost;User Id=SA; Password=ThisIsIPScannerPa$$w0rd97;TrustServerCertificate=True; Database=ipscanner";
        //    //optionsBuilder.UseSqlServer(connection_string);
        //}
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataDbContext).Assembly);
        }

    }
}