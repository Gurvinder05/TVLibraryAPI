﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TVLibraryAPI.Data;

namespace TVLibraryAPI.Migrations
{
    [DbContext(typeof(ShowDBContext))]
    partial class ShowDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TVLibraryAPI.Models.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Platforms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Netflix"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Prime"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hotstar"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Zee5"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Voot"
                        });
                });

            modelBuilder.Entity("TVLibraryAPI.Models.Show", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.Property<string>("Schedule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlatformId");

                    b.ToTable("Shows");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PlatformId = 1,
                            Schedule = "Season",
                            Summary = "The witcher Geralt, a mutated monster hunter, struggles to find his place in a world in which people often prove more wicked than beasts.",
                            Title = "The Witcher"
                        },
                        new
                        {
                            Id = 2,
                            PlatformId = 2,
                            Schedule = "Season",
                            Summary = "Akhandanand Tripathi made millions exporting carpets and became the mafia boss of Mirzapur. His son Munna, an unworthy, power-hungry heir, stops at nothing to continue his father's legacy.",
                            Title = "Mirzapur"
                        },
                        new
                        {
                            Id = 3,
                            PlatformId = 3,
                            Schedule = "Weekly",
                            Summary = "Chuck Rhoades, a sincere but ruthless US attorney, engages in an egoistic battle with hedge fund kingpin Bobby 'Axe' Axelrod as they try to outdo each other in the competitive financial market.",
                            Title = "Billions"
                        });
                });

            modelBuilder.Entity("TVLibraryAPI.Models.Show", b =>
                {
                    b.HasOne("TVLibraryAPI.Models.Platform", "Platform")
                        .WithMany("shows")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
