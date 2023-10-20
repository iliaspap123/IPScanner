using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class IPDetailsConfiguration : IEntityTypeConfiguration<IPDetails>
    {
        public void Configure(EntityTypeBuilder<IPDetails> builder)
        {
            builder.HasKey(p => p.IP);
        }
    }
}
