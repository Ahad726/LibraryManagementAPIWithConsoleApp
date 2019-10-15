﻿// <auto-generated />
using System;
using LibraryWebAPI.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryWebAPI.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibraryWebAPI.Core.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aurthor");

                    b.Property<string>("Barcode");

                    b.Property<int>("CopyCount");

                    b.Property<string>("Edition");

                    b.Property<string>("Title");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibraryWebAPI.Core.IssueBook", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("BookId");

                    b.Property<string>("BookBarCode");

                    b.Property<DateTime>("IssueDate");

                    b.HasKey("StudentId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("IssueBooks");
                });

            modelBuilder.Entity("LibraryWebAPI.Core.ReturnBook", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("BookId");

                    b.Property<string>("BookBarCode");

                    b.Property<DateTime>("ReturnDate");

                    b.HasKey("StudentId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("ReturnBooks");
                });

            modelBuilder.Entity("LibraryWebAPI.Core.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Fine");

                    b.Property<string>("Name");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("LibraryWebAPI.Core.IssueBook", b =>
                {
                    b.HasOne("LibraryWebAPI.Core.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LibraryWebAPI.Core.Student", "Student")
                        .WithMany("IssueBooks")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LibraryWebAPI.Core.ReturnBook", b =>
                {
                    b.HasOne("LibraryWebAPI.Core.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LibraryWebAPI.Core.Student", "Student")
                        .WithMany("ReturnBooks")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
