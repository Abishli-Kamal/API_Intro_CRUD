using API_Intro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Intro.ProductConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(s => s.Name).IsRequired().HasMaxLength(30);
            builder.Property(s => s.Price).IsRequired();
            builder.Property(s=>s.IsStatus).IsRequired().HasDefaultValue(true);

        }
      
    }
}
