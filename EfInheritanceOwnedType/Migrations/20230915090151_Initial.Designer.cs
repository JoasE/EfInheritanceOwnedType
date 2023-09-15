﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfInheritanceOwnedType.Migrations
{
    [DbContext(typeof(TestDbContext))]
    [Migration("20230915090151_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-rc.1.23419.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BaseType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("SubTypeOne", b =>
                {
                    b.HasBaseType("BaseType");

                    b.ToTable("SubTypeOnes");
                });

            modelBuilder.Entity("SubTypeTwo", b =>
                {
                    b.HasBaseType("BaseType");

                    b.ToTable("SubTypeTwos");
                });

            modelBuilder.Entity("BaseType", b =>
                {
                    b.OwnsOne("OwnedType", "OwnedType", b1 =>
                        {
                            b1.Property<Guid>("BaseTypeId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("BaseTypeId");

                            b1.ToTable((string)null);

                            b1.WithOwner()
                                .HasForeignKey("BaseTypeId");
                        });

                    b.Navigation("OwnedType")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}