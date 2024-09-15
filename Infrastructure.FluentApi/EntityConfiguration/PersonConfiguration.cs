using Domain.Entities.AddressAggreagte;
using Domain.Entities.FoodAggregate;
using Domain.Entities.FoodCategoryAggregate;
using Domain.Entities.OperatoreAggregate;
using Domain.Entities.PersonAggregate;
using Domain.Entities.ReciveAggregate;
using Domain.Entities.ReserveAggregate;
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

            builder.Property(e=>e.HourseOfWork).IsRequired();
            builder.Property(e=>e.TimeOfContract).IsRequired();

            builder.Property(e=>e.FullName).HasMaxLength(100)
                .HasAnnotation("MinLength",10).IsRequired();


            builder.HasMany(e => e.DaysOfWeeksForWork).WithMany(d => d.employers).UsingEntity(p =>
            {
                p.HasKey("Id","Id");
            });

            builder.HasOne(e=>e.HourseOfWork).WithMany(h=>h.Employers).OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(h=>h.HourseOfWork).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(e=>e.Recives).WithOne(r=>r.Employer).HasForeignKey(r=>r.EmployerId)
                .OnDelete(DeleteBehavior.SetNull);
        }

    }

    public class FoodCategoryConfiguration : IEntityTypeConfiguration<FoodCategory>
    {
        public void Configure(EntityTypeBuilder<FoodCategory> builder)
        {
            builder.HasKey(f=>f.Id);


            builder.Property(p=>p.IsActive).IsRequired();
            builder.Property(p=>p.CategoryName)
                .HasAnnotation("MinLength",5).IsRequired().HasMaxLength(50);
            builder.Property(p=>p.CreationDate).IsRequired();

            builder.HasMany<FoodCategory>(f=>f.SubCategory)
                .WithOne(f=>f.ParentCategory).HasForeignKey(f=>f.ParentCategoryId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(f=>f.Foods).WithOne(f=>f.FoodCategory).HasForeignKey(f=>f.FoodCategoryId);

        }
    }
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasKey(f=>f.Id);
            builder.Property(f=>f.SuitableHowMany).IsRequired();
            builder.Property(f=>f.Prise).IsRequired().HasAnnotation("Range",new { Min = 1000,Max=1000000000} );
            builder.Property(f=>f.FileId).IsRequired();
            builder.Property(f=>f.FoodCategoryId).IsRequired();
            builder.Property(f=>f.Name).IsRequired().HasAnnotation("MinLength",5).HasMaxLength(70);
            builder.Property(f=>f.Weight).HasAnnotation("Range",new{Min= 50,Max=500000 });

            builder.HasMany(f => f.Reserves).WithMany(r => r.Foods).UsingEntity(p =>
            {
                p.HasKey("Id","Id");
            });

            builder.HasOne(f=>f.FoodCategory).WithMany(fc=>fc.Foods).HasForeignKey(f=>f.FoodCategoryId);

            builder.OwnsOne(f=>f.FoodFile).OwnsOne(ff=>ff.Food);
        }
    }

    public class ReserveConfiguration : IEntityTypeConfiguration<Reserve>
    {
        public void Configure(EntityTypeBuilder<Reserve> builder)
        {
            builder.HasKey(r=>r.Id);

            builder.Property(r=>r.IsActive).IsRequired();
            builder.Property(r=>r.ReserveDate).IsRequired();
            builder.Property(r=>r.Addressid).IsRequired();
            builder.Property(r=>r.CreateReserveTime).IsRequired();

            builder.HasOne(r=>r.Person).WithMany(p=>p.Reserves).HasForeignKey(r=>r.PersonId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(r => r.Foods).WithMany(f => f.Reserves).UsingEntity(p =>
            {
                p.HasKey("Id","Id");
            });

            builder.HasOne(r=>r.Address).WithMany(a=>a.Reserves).HasForeignKey(r=>r.Addressid)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(r=>r.Recive).WithOne(re=>re.Reserve)
                .HasForeignKey<Recive>(r=>r.ReserveId).OnDelete(DeleteBehavior.SetNull);
        }
    }

    public class ReciveConfiguration : IEntityTypeConfiguration<Recive>
    {
        public void Configure(EntityTypeBuilder<Recive> builder)
        {
            builder.HasKey(p=>p.ReserveId);
            builder.Property(r=>r.PayType).IsRequired();
            builder.HasOne(r=>r.Employer).WithMany(e=>e.Recives)
               .HasForeignKey(r=>r.EmployerId).OnDelete(DeleteBehavior.NoAction);
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