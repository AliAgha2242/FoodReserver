using Domain.Entities.AddressAggreagte;
using Domain.Entities.OperatoreAggregate;
using Domain.Entities.PersonAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Infrastructure.FluentApi.EntityConfiguration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {

        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.PasswordSalt).IsRequired();
            builder.Property(p => p.FullPassword).IsRequired();
            builder.Property(p => p.CreationDate).IsRequired();


            builder.Property(p => p.Email).HasAnnotation("EmailAddress", null)
                .IsRequired();

            builder.Property(p => p.PhoneNumber).HasAnnotation("MinLength", 11)
                .IsRequired().HasMaxLength(11);

            builder.Property(p => p.PersonName).HasAnnotation("MinLength", 10)
                .IsRequired().HasMaxLength(50);

            builder.Property(p => p.FullPassword).IsRequired();

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


    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a=>a.Id);
            builder.Property(a=>a.RestAddress).HasAnnotation("MinLngth",20)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(a=>a.Ostan)
                .IsRequired();

            builder.Property(a=>a.Shahr)
                .IsRequired();

            builder.Property(a=>a.PostalCode).HasAnnotation("MinLength",10)
                .IsRequired().HasMaxLength(10);

            builder.Property(a=>a.Pelak).IsRequired();


            builder.HasOne(a=>a.Person).WithMany(p => p.Addresses)
                .HasForeignKey(a=>a.PersonId).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(a=>a.Reserves).WithOne(r=>r.Address)
                .HasForeignKey(r=>r.Addressid).OnDelete(DeleteBehavior.NoAction);
            
        }
    }

    public class EmployerConfiguration : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.Property(e=>e.EmployerCode).HasAnnotation("MinLength",10)
                .IsRequired().HasMaxLength (100);

            builder.Property(e=>e.UserName).HasAnnotation("MinLength",5)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e=>e.HourseOfWorks).IsRequired();
            builder.Property(e=>e.TimeOfContract).IsRequired();

            builder.Property(e=>e.FullName).HasMaxLength(100)
                .HasAnnotation("MinLength",10).IsRequired();


            builder.OwnsMany(e => e.DaysOfWeeksForWork).OwnsMany(d => d.employers);
        }
    }
}