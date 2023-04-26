using BankApiRESTful.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApiRESTful.Persintence.Configuration
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .HasMaxLength(80)
                   .IsRequired();

            builder.Property(x => x.LastName)
                   .HasMaxLength(80)
                   .IsRequired();

            builder.Property(x => x.Name)
                   .HasMaxLength(80)
                   .IsRequired();

            builder.Property(x => x.Birthdate)
                   .IsRequired();

            builder.Property(x => x.Email)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.PhoneNumber)
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(x => x.PhoneNumber)
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(x => x.Address)
                   .HasMaxLength(120)
                   .IsRequired();

            builder.Property(x => x.Age);

            builder.Property(x => x.CreateBy)
                   .HasMaxLength(30);

            builder.Property(x => x.LastModifiedBy)
                   .HasMaxLength(30);
        }
    }
}
