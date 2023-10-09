﻿// <auto-generated />
using System;
using ContactRegistration.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContactRegistration.Infrastructure.Migrations
{
    [DbContext(typeof(ContactRegistrationDbContext))]
    partial class ContactRegistrationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("ContactRegistration.Domain.Entities.Contact", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<DateOnly?>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("dateOfBirth");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("contact", (string)null);
                });

            modelBuilder.Entity("ContactRegistration.Domain.Entities.Email", b =>
                {
                    b.Property<long>("EmailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("emailId")
                        .HasColumnOrder(0);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar")
                        .HasColumnName("address");

                    b.Property<long>("ContactId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("INTEGER");

                    b.HasKey("EmailId");

                    b.HasIndex("ContactId");

                    b.ToTable("email", (string)null);
                });

            modelBuilder.Entity("ContactRegistration.Domain.Entities.Email", b =>
                {
                    b.HasOne("ContactRegistration.Domain.Entities.Contact", "Contact")
                        .WithMany("Emails")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("ContactRegistration.Domain.Entities.Contact", b =>
                {
                    b.Navigation("Emails");
                });
#pragma warning restore 612, 618
        }
    }
}
