﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheCatApiV2.Data;

#nullable disable

namespace TheCatApiV2.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231014161643_Ajout de la configuration dans database Context")]
    partial class AjoutdelaconfigurationdansdatabaseContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DatabaseModels.PictureDatabaseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BreedId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NumberBad")
                        .HasColumnType("int");

                    b.Property<int>("NumberLiked")
                        .HasColumnType("int");

                    b.Property<string>("UrlPicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BreedId");

                    b.ToTable("PicturesDatabaseModel");
                });

            modelBuilder.Entity("DatabaseModels.PictureJoinedDatabaseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("bit");

                    b.Property<int>("PictureId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PictureId");

                    b.HasIndex("UserId");

                    b.ToTable("PicturesJoinedDatabaseModels");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityUser");
                });

            modelBuilder.Entity("TheCatApiV2.DatabaseModels.BreedDatabaseModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Adaptability")
                        .HasColumnType("int");

                    b.Property<int?>("AffectionLevel")
                        .HasColumnType("int");

                    b.Property<string>("AltNames")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CfaUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ChildFriendly")
                        .HasColumnType("int");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCodes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DogFriendly")
                        .HasColumnType("int");

                    b.Property<int?>("EnergyLevel")
                        .HasColumnType("int");

                    b.Property<int?>("Experimental")
                        .HasColumnType("int");

                    b.Property<int?>("Grooming")
                        .HasColumnType("int");

                    b.Property<int?>("Hairless")
                        .HasColumnType("int");

                    b.Property<int?>("HealthIssues")
                        .HasColumnType("int");

                    b.Property<int?>("Hypoallergenic")
                        .HasColumnType("int");

                    b.Property<string>("Imperial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Indoor")
                        .HasColumnType("int");

                    b.Property<int?>("Intelligence")
                        .HasColumnType("int");

                    b.Property<int?>("Lap")
                        .HasColumnType("int");

                    b.Property<string>("LifeSpan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Metric")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Natural")
                        .HasColumnType("int");

                    b.Property<string>("Origin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rare")
                        .HasColumnType("int");

                    b.Property<string>("ReferenceImageId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rex")
                        .HasColumnType("int");

                    b.Property<int?>("SheddingLevel")
                        .HasColumnType("int");

                    b.Property<int?>("ShortLegs")
                        .HasColumnType("int");

                    b.Property<int?>("SocialNeeds")
                        .HasColumnType("int");

                    b.Property<int?>("StrangerFriendly")
                        .HasColumnType("int");

                    b.Property<int?>("SuppressedTail")
                        .HasColumnType("int");

                    b.Property<string>("Temperament")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VcahospitalsUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VetstreetUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Vocalisation")
                        .HasColumnType("int");

                    b.Property<string>("WikipediaUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BreedsDatabaseModel");
                });

            modelBuilder.Entity("DatabaseModels.PictureDatabaseModel", b =>
                {
                    b.HasOne("TheCatApiV2.DatabaseModels.BreedDatabaseModel", "Breed")
                        .WithMany("pictures")
                        .HasForeignKey("BreedId");

                    b.Navigation("Breed");
                });

            modelBuilder.Entity("DatabaseModels.PictureJoinedDatabaseModel", b =>
                {
                    b.HasOne("DatabaseModels.PictureDatabaseModel", "Picture")
                        .WithMany("Pictures")
                        .HasForeignKey("PictureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Picture");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DatabaseModels.PictureDatabaseModel", b =>
                {
                    b.Navigation("Pictures");
                });

            modelBuilder.Entity("TheCatApiV2.DatabaseModels.BreedDatabaseModel", b =>
                {
                    b.Navigation("pictures");
                });
#pragma warning restore 612, 618
        }
    }
}