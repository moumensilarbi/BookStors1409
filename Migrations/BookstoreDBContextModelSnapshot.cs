﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bookstore.Models;

namespace bookstore.Migrations
{
    [DbContext(typeof(BookstoreDBContext))]
    partial class BookstoreDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("bookstore.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("bookstore.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descreption");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Title");

                    b.Property<int?>("authorId");

                    b.HasKey("Id");

                    b.HasIndex("authorId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("bookstore.Models.Book", b =>
                {
                    b.HasOne("bookstore.Models.Author", "author")
                        .WithMany()
                        .HasForeignKey("authorId");
                });
#pragma warning restore 612, 618
        }
    }
}
