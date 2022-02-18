﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PermitApplications.Persistence.Contexts.Khensys;

namespace PermitApplications.Persistance.Migrations
{
    [DbContext(typeof(KhensysDbContext))]
    partial class KhensysDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PermitApplications.Persistence.Entities.Permit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("EmployeeLastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("PermitDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("PermitTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PermitTypeId");

                    b.ToTable("Permit");
                });

            modelBuilder.Entity("PermitApplications.Persistence.Entities.PermitType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PermitType");
                });

            modelBuilder.Entity("PermitApplications.Persistence.Entities.Permit", b =>
                {
                    b.HasOne("PermitApplications.Persistence.Entities.PermitType", "PermitType")
                        .WithMany()
                        .HasForeignKey("PermitTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
