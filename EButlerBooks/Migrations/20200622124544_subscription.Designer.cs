﻿// <auto-generated />
using EButlerBooks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EButlerBooks.Migrations
{
    [DbContext(typeof(DbEntities))]
    [Migration("20200622124544_subscription")]
    partial class subscription
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EButlerBooks.Models.AppSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BannerImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FeaturedBookId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FeaturedBookId");

                    b.ToTable("AppSettings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FeaturedBookId = 1
                        });
                });

            modelBuilder.Entity("EButlerBooks.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Eric",
                            LastName = "Butler"
                        });
                });

            modelBuilder.Entity("EButlerBooks.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ComingSoon")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFeatured")
                        .HasColumnType("bit");

                    b.Property<string>("ThumbImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ComingSoon = false,
                            Description = "A book about a dark world.",
                            FullDescription = "In a world where darkness is everywhere, one woman fights to bring it light.",
                            IsFeatured = false,
                            Title = "Dark World"
                        },
                        new
                        {
                            Id = 2,
                            ComingSoon = false,
                            Description = "Robots. A.I.",
                            FullDescription = "Angie Gordon get trapped in her worst nightmare",
                            IsFeatured = false,
                            Title = "Angie Gordon"
                        },
                        new
                        {
                            Id = 3,
                            ComingSoon = false,
                            Description = "Boy kidnaps girl",
                            FullDescription = "Boy kidnaps girl and takes her to a fantasy realm to help him find his long-lost sister.",
                            IsFeatured = false,
                            Title = "Fantasy"
                        });
                });

            modelBuilder.Entity("EButlerBooks.Models.BookAuthors", b =>
                {
                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("AuthorId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("BookAuthors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            BookId = 1
                        },
                        new
                        {
                            AuthorId = 1,
                            BookId = 2
                        },
                        new
                        {
                            AuthorId = 1,
                            BookId = 3
                        });
                });

            modelBuilder.Entity("EButlerBooks.Models.BookGenres", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("GenreId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("BookGenres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            BookId = 1
                        },
                        new
                        {
                            GenreId = 2,
                            BookId = 1
                        },
                        new
                        {
                            GenreId = 2,
                            BookId = 2
                        },
                        new
                        {
                            GenreId = 1,
                            BookId = 3
                        });
                });

            modelBuilder.Entity("EButlerBooks.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Science Fiction"
                        });
                });

            modelBuilder.Entity("EButlerBooks.Models.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("EButlerBooks.Models.AppSettings", b =>
                {
                    b.HasOne("EButlerBooks.Models.Book", "FeaturedBook")
                        .WithMany()
                        .HasForeignKey("FeaturedBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EButlerBooks.Models.BookAuthors", b =>
                {
                    b.HasOne("EButlerBooks.Models.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EButlerBooks.Models.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EButlerBooks.Models.BookGenres", b =>
                {
                    b.HasOne("EButlerBooks.Models.Book", "Book")
                        .WithMany("BookGenres")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EButlerBooks.Models.Genre", "Genre")
                        .WithMany("BookGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
