using Domain.Customers;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.persistence.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            customerId => customerId.Value,
            value => new CustomerId(value));


        builder.Property(c => c.Name).HasMaxLength(50);

        builder.Property(c => c.LastName).HasMaxLength(50);

        builder.Property(c => c.Email).HasMaxLength(255);

        builder.Ignore(c => c.FullName);

        builder.HasIndex(c => c.Email).IsUnique();


        builder.Property(c => c.PhoneNumber).HasConversion(
            phoneNumber => phoneNumber.Value,
            value => PhoneNumber.Create(value)!)
            .HasMaxLength(10);

        builder.OwnsOne(c => c.Adress, adressBuilder =>
        {
            adressBuilder.Property(a => a.Country).HasMaxLength(3);

            adressBuilder.Property(a => a.Line1).HasMaxLength(20);

            adressBuilder.Property(a => a.Line2).HasMaxLength(20).IsRequired(false);

            adressBuilder.Property(a => a.City).HasMaxLength(50);

            adressBuilder.Property(a => a.State).HasMaxLength(50);

            adressBuilder.Property(a => a.ZipCode).HasMaxLength(10);

        });

        builder.Property(c => c.Active);


    }
}