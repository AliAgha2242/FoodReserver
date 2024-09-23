using Domain.Entities.PersonAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FluentApi.EntityConfiguration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {

        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.PasswordSalt).IsRequired();
            builder.Property(p => p.CreationDate).IsRequired();


            builder.Property(p => p.Email).HasAnnotation("EmailAddress", null)
                .IsRequired();

            builder.Property(p => p.PhoneNumber).HasAnnotation("MinLength", 11)
                .IsRequired().HasMaxLength(11);

            builder.Property(p => p.PersonName).HasAnnotation("MinLength", 10)
                .IsRequired().HasMaxLength(50);


            builder.Property(p => p.FullName).HasAnnotation("MinLength", 10)
                .IsRequired().HasMaxLength(50);

            builder.HasMany(p => p.Reserves)
                .WithOne(r => r.Person)
                .HasForeignKey(r => r.PersonId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(p => p.Addresses)
                .WithOne(A => A.Person)
                .HasForeignKey(A => A.PersonId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }

    //public class ReciveConfiguration : IEntityTypeConfiguration<Recive>
    //{
    //    public void Configure(EntityTypeBuilder<Recive> builder)
    //    {
    //        builder.HasKey(r=>r.Id);
    //        builder.Property(r=>r.PayType).IsRequired();
    //        builder.Property(r=>r.ReserveId).IsRequired();


    //        builder.HasOne(r=>r.Reserve).WithOne(re=>re.Recive);
    //        builder.HasOne(r=>r.Employer).WithMany(e=>e.Recives)
    //            .HasForeignKey(r=>r.EmployerId).OnDelete(DeleteBehavior.NoAction);


    //    }
    //}
}
