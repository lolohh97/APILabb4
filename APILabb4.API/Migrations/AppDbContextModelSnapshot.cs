﻿// <auto-generated />
using APILabb4.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APILabb4.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APILabb4.Models.Hobby", b =>
                {
                    b.Property<int>("HobbyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HobbyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HobbyId");

                    b.ToTable("Hobbies");

                    b.HasData(
                        new
                        {
                            HobbyId = 1,
                            Description = "Drawing, painting, sculpting, crafts, DIY",
                            HobbyName = "Art"
                        },
                        new
                        {
                            HobbyId = 2,
                            Description = "Ballsports, swimming, martial arts, jogging, dancing",
                            HobbyName = "Sports"
                        },
                        new
                        {
                            HobbyId = 3,
                            Description = "Cooking food, baking",
                            HobbyName = "Cooking"
                        },
                        new
                        {
                            HobbyId = 4,
                            Description = "Singing, playing instruments, production",
                            HobbyName = "Music"
                        });
                });

            modelBuilder.Entity("APILabb4.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            Address = "Skånegatan 17",
                            Email = "lolo@hot.com",
                            FirstName = "Lina",
                            LastName = "Haytham",
                            Phone = "0761121112"
                        },
                        new
                        {
                            PersonId = 2,
                            Address = "Kvarnängsgatan 24",
                            Email = "jojo@hot.com",
                            FirstName = "Jones",
                            LastName = "Haytham",
                            Phone = "0735454123"
                        },
                        new
                        {
                            PersonId = 3,
                            Address = "Kungsgatan 5",
                            Email = "nata@hot.com",
                            FirstName = "Natalia",
                            LastName = "Al",
                            Phone = "0707654321"
                        });
                });

            modelBuilder.Entity("APILabb4.Models.PersonHobby", b =>
                {
                    b.Property<int>("PersonHobbyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HobbyId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("WebLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonHobbyId");

                    b.HasIndex("HobbyId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonHobbies");

                    b.HasData(
                        new
                        {
                            PersonHobbyId = 1,
                            HobbyId = 3,
                            PersonId = 1,
                            WebLink = "www.recepten.se/"
                        },
                        new
                        {
                            PersonHobbyId = 2,
                            HobbyId = 3,
                            PersonId = 1,
                            WebLink = "www.koket.se/"
                        },
                        new
                        {
                            PersonHobbyId = 3,
                            HobbyId = 2,
                            PersonId = 2,
                            WebLink = "www.bet365.com/"
                        },
                        new
                        {
                            PersonHobbyId = 4,
                            HobbyId = 3,
                            PersonId = 2,
                            WebLink = "www.koket.se/"
                        },
                        new
                        {
                            PersonHobbyId = 5,
                            HobbyId = 1,
                            PersonId = 3,
                            WebLink = "diysweden.se"
                        },
                        new
                        {
                            PersonHobbyId = 6,
                            HobbyId = 4,
                            PersonId = 3,
                            WebLink = "soundcloud.com"
                        });
                });

            modelBuilder.Entity("APILabb4.Models.PersonHobby", b =>
                {
                    b.HasOne("APILabb4.Models.Hobby", "Hobby")
                        .WithMany("PersonHobbies")
                        .HasForeignKey("HobbyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APILabb4.Models.Person", "Person")
                        .WithMany("PersonHobbies")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
