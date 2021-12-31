using Mc2.CrudTest.Core.Domian;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mc2.CrudTest.Data.Mapping
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(p => p.CountryCode).IsRequired().HasColumnType("varchar").HasMaxLength(2);
            builder.Property(p => p.PhoneNumber).IsRequired().HasColumnType("varchar").HasMaxLength(11);
          
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(150);
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(150);

            builder.Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Property(p => p.BankAccountNumber).IsRequired().HasMaxLength(50);

        }
    }
}
