﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using star_wars_api.Data;

namespace star_wars_api.Migrations
{
    [DbContext(typeof(star_wars_apiContext))]
    [Migration("20201228160906_changeToIntNullable")]
    partial class changeToIntNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("star_wars_api.Models.Character", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("birthYear")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("edited")
                        .HasColumnType("TEXT");

                    b.Property<string>("eyeColor")
                        .HasColumnType("TEXT");

                    b.Property<string>("gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("hairColor")
                        .HasColumnType("TEXT");

                    b.Property<int?>("height")
                        .HasColumnType("INTEGER");

                    b.Property<int>("homeworldId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("mass")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Character");
                });

            modelBuilder.Entity("star_wars_api.Models.Film", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("created")
                        .HasColumnType("TEXT");

                    b.Property<string>("director")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("edited")
                        .HasColumnType("TEXT");

                    b.Property<int>("episodeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("openingCrawl")
                        .HasColumnType("TEXT");

                    b.Property<string>("producer")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("releaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("title")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Film");
                });

            modelBuilder.Entity("star_wars_api.Models.FilmCharacter", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FilmId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("FilmCharacter");
                });

            modelBuilder.Entity("star_wars_api.Models.FilmPlanet", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlanetId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FilmId", "PlanetId");

                    b.HasIndex("PlanetId");

                    b.ToTable("FilmPlanet");
                });

            modelBuilder.Entity("star_wars_api.Models.FilmSpecies", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpeciesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FilmId", "SpeciesId");

                    b.HasIndex("SpeciesId");

                    b.ToTable("FilmSpecies");
                });

            modelBuilder.Entity("star_wars_api.Models.FilmStarship", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StarshipId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FilmId", "StarshipId");

                    b.ToTable("FilmStarship");
                });

            modelBuilder.Entity("star_wars_api.Models.FilmVehicle", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VehicleId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Starshipid")
                        .HasColumnType("INTEGER");

                    b.HasKey("FilmId", "VehicleId");

                    b.HasIndex("Starshipid");

                    b.HasIndex("VehicleId");

                    b.ToTable("FilmVehicle");
                });

            modelBuilder.Entity("star_wars_api.Models.Planet", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("climate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("created")
                        .HasColumnType("TEXT");

                    b.Property<int>("diameter")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("edited")
                        .HasColumnType("TEXT");

                    b.Property<string>("gravity")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<int>("orbitalPeriod")
                        .HasColumnType("INTEGER");

                    b.Property<int>("population")
                        .HasColumnType("INTEGER");

                    b.Property<string>("rotationPeriod")
                        .HasColumnType("TEXT");

                    b.Property<string>("surfaceWater")
                        .HasColumnType("TEXT");

                    b.Property<string>("terrain")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Planet");
                });

            modelBuilder.Entity("star_wars_api.Models.PlanetCharacter", b =>
                {
                    b.Property<int>("planetId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("characterId")
                        .HasColumnType("INTEGER");

                    b.HasKey("planetId", "characterId");

                    b.ToTable("PlanetCharacter");
                });

            modelBuilder.Entity("star_wars_api.Models.Species", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("averageHeight")
                        .HasColumnType("REAL");

                    b.Property<int>("averageLifespan")
                        .HasColumnType("INTEGER");

                    b.Property<string>("classification")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("created")
                        .HasColumnType("TEXT");

                    b.Property<string>("designation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("edited")
                        .HasColumnType("TEXT");

                    b.Property<int>("homeworldId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("language")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("star_wars_api.Models.SpeciesCharacter", b =>
                {
                    b.Property<int>("speciesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("characterId")
                        .HasColumnType("INTEGER");

                    b.HasKey("speciesId", "characterId");

                    b.HasIndex("characterId");

                    b.ToTable("SpeciesCharacter");
                });

            modelBuilder.Entity("star_wars_api.Models.SpeciesEyeColor", b =>
                {
                    b.Property<int>("speciesId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("eyeColor")
                        .HasColumnType("TEXT");

                    b.HasKey("speciesId", "eyeColor");

                    b.ToTable("SpeciesEyeColor");
                });

            modelBuilder.Entity("star_wars_api.Models.SpeciesHairColor", b =>
                {
                    b.Property<int>("speciesId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("hairColor")
                        .HasColumnType("TEXT");

                    b.HasKey("speciesId", "hairColor");

                    b.ToTable("SpeciesHairColor");
                });

            modelBuilder.Entity("star_wars_api.Models.SpeciesSkinColor", b =>
                {
                    b.Property<int>("speciesId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("skinColor")
                        .HasColumnType("TEXT");

                    b.HasKey("speciesId", "skinColor");

                    b.ToTable("SpeciesSkinColor");
                });

            modelBuilder.Entity("star_wars_api.Models.Starship", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("cargoCapacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("consumables")
                        .HasColumnType("TEXT");

                    b.Property<int>("costInCredits")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("created")
                        .HasColumnType("TEXT");

                    b.Property<string>("crew")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("edited")
                        .HasColumnType("TEXT");

                    b.Property<double>("hyperdriveRating")
                        .HasColumnType("REAL");

                    b.Property<string>("length")
                        .HasColumnType("TEXT");

                    b.Property<string>("manufacturer")
                        .HasColumnType("TEXT");

                    b.Property<string>("mglt")
                        .HasColumnType("TEXT");

                    b.Property<string>("model")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<int>("passengers")
                        .HasColumnType("INTEGER");

                    b.Property<string>("starshipClass")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Starship");
                });

            modelBuilder.Entity("star_wars_api.Models.StarshipCharacter", b =>
                {
                    b.Property<int>("starshipId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("characterId")
                        .HasColumnType("INTEGER");

                    b.HasKey("starshipId", "characterId");

                    b.HasIndex("characterId");

                    b.ToTable("StarshipCharacter");
                });

            modelBuilder.Entity("star_wars_api.Models.Vehicle", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("cargoCapacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("consumables")
                        .HasColumnType("TEXT");

                    b.Property<int>("costInCredits")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("created")
                        .HasColumnType("TEXT");

                    b.Property<string>("crew")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("edited")
                        .HasColumnType("TEXT");

                    b.Property<string>("length")
                        .HasColumnType("TEXT");

                    b.Property<string>("manufacturer")
                        .HasColumnType("TEXT");

                    b.Property<string>("model")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<int>("passengers")
                        .HasColumnType("INTEGER");

                    b.Property<string>("vehicleClass")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("star_wars_api.Models.VehicleCharacter", b =>
                {
                    b.Property<int>("vehicleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("characterId")
                        .HasColumnType("INTEGER");

                    b.HasKey("vehicleId", "characterId");

                    b.HasIndex("characterId");

                    b.ToTable("VehicleCharacter");
                });

            modelBuilder.Entity("star_wars_api.Models.FilmCharacter", b =>
                {
                    b.HasOne("star_wars_api.Models.Character", null)
                        .WithMany("filmIds")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("star_wars_api.Models.Film", null)
                        .WithMany("characterIds")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("star_wars_api.Models.FilmPlanet", b =>
                {
                    b.HasOne("star_wars_api.Models.Film", null)
                        .WithMany("planetIds")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("star_wars_api.Models.Planet", null)
                        .WithMany("filmIds")
                        .HasForeignKey("PlanetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("star_wars_api.Models.FilmSpecies", b =>
                {
                    b.HasOne("star_wars_api.Models.Film", null)
                        .WithMany("speciesIds")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("star_wars_api.Models.Species", null)
                        .WithMany("filmIds")
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("star_wars_api.Models.FilmStarship", b =>
                {
                    b.HasOne("star_wars_api.Models.Film", null)
                        .WithMany("starshipIds")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("star_wars_api.Models.FilmVehicle", b =>
                {
                    b.HasOne("star_wars_api.Models.Film", null)
                        .WithMany("vehicleIds")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("star_wars_api.Models.Starship", null)
                        .WithMany("filmIds")
                        .HasForeignKey("Starshipid");

                    b.HasOne("star_wars_api.Models.Vehicle", null)
                        .WithMany("filmIds")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("star_wars_api.Models.PlanetCharacter", b =>
                {
                    b.HasOne("star_wars_api.Models.Planet", null)
                        .WithMany("residentIds")
                        .HasForeignKey("planetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("star_wars_api.Models.SpeciesCharacter", b =>
                {
                    b.HasOne("star_wars_api.Models.Character", null)
                        .WithMany("speciesIds")
                        .HasForeignKey("characterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("star_wars_api.Models.Species", null)
                        .WithMany("peopleIds")
                        .HasForeignKey("speciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("star_wars_api.Models.SpeciesEyeColor", b =>
                {
                    b.HasOne("star_wars_api.Models.Species", null)
                        .WithMany("eyeColors")
                        .HasForeignKey("speciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("star_wars_api.Models.SpeciesHairColor", b =>
                {
                    b.HasOne("star_wars_api.Models.Species", null)
                        .WithMany("hairColors")
                        .HasForeignKey("speciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("star_wars_api.Models.SpeciesSkinColor", b =>
                {
                    b.HasOne("star_wars_api.Models.Species", null)
                        .WithMany("skinColors")
                        .HasForeignKey("speciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("star_wars_api.Models.StarshipCharacter", b =>
                {
                    b.HasOne("star_wars_api.Models.Character", null)
                        .WithMany("starshipIds")
                        .HasForeignKey("characterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("star_wars_api.Models.Starship", null)
                        .WithMany("pilotIds")
                        .HasForeignKey("starshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("star_wars_api.Models.VehicleCharacter", b =>
                {
                    b.HasOne("star_wars_api.Models.Character", null)
                        .WithMany("vehicleIds")
                        .HasForeignKey("characterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("star_wars_api.Models.Vehicle", null)
                        .WithMany("pilotIds")
                        .HasForeignKey("vehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("star_wars_api.Models.Character", b =>
                {
                    b.Navigation("filmIds");

                    b.Navigation("speciesIds");

                    b.Navigation("starshipIds");

                    b.Navigation("vehicleIds");
                });

            modelBuilder.Entity("star_wars_api.Models.Film", b =>
                {
                    b.Navigation("characterIds");

                    b.Navigation("planetIds");

                    b.Navigation("speciesIds");

                    b.Navigation("starshipIds");

                    b.Navigation("vehicleIds");
                });

            modelBuilder.Entity("star_wars_api.Models.Planet", b =>
                {
                    b.Navigation("filmIds");

                    b.Navigation("residentIds");
                });

            modelBuilder.Entity("star_wars_api.Models.Species", b =>
                {
                    b.Navigation("eyeColors");

                    b.Navigation("filmIds");

                    b.Navigation("hairColors");

                    b.Navigation("peopleIds");

                    b.Navigation("skinColors");
                });

            modelBuilder.Entity("star_wars_api.Models.Starship", b =>
                {
                    b.Navigation("filmIds");

                    b.Navigation("pilotIds");
                });

            modelBuilder.Entity("star_wars_api.Models.Vehicle", b =>
                {
                    b.Navigation("filmIds");

                    b.Navigation("pilotIds");
                });
#pragma warning restore 612, 618
        }
    }
}
