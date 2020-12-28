using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace star_wars_api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    height = table.Column<int>(type: "INTEGER", nullable: false),
                    mass = table.Column<int>(type: "INTEGER", nullable: false),
                    hairColor = table.Column<string>(type: "TEXT", nullable: true),
                    eyeColor = table.Column<string>(type: "TEXT", nullable: true),
                    birthYear = table.Column<string>(type: "TEXT", nullable: true),
                    gender = table.Column<string>(type: "TEXT", nullable: true),
                    homeworldId = table.Column<int>(type: "INTEGER", nullable: false),
                    created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    edited = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    director = table.Column<string>(type: "TEXT", nullable: true),
                    episodeId = table.Column<int>(type: "INTEGER", nullable: false),
                    openingCrawl = table.Column<string>(type: "TEXT", nullable: true),
                    producer = table.Column<string>(type: "TEXT", nullable: true),
                    releaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    edited = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Planet",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    climate = table.Column<string>(type: "TEXT", nullable: true),
                    diameter = table.Column<int>(type: "INTEGER", nullable: false),
                    gravity = table.Column<string>(type: "TEXT", nullable: true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    orbitalPeriod = table.Column<int>(type: "INTEGER", nullable: false),
                    population = table.Column<int>(type: "INTEGER", nullable: false),
                    rotationPeriod = table.Column<string>(type: "TEXT", nullable: true),
                    surfaceWater = table.Column<string>(type: "TEXT", nullable: true),
                    terrain = table.Column<string>(type: "TEXT", nullable: true),
                    created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    edited = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planet", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    averageHeight = table.Column<double>(type: "REAL", nullable: false),
                    averageLifespan = table.Column<int>(type: "INTEGER", nullable: false),
                    classification = table.Column<string>(type: "TEXT", nullable: true),
                    designation = table.Column<string>(type: "TEXT", nullable: true),
                    homeworldId = table.Column<int>(type: "INTEGER", nullable: false),
                    language = table.Column<string>(type: "TEXT", nullable: true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    edited = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Starship",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    mglt = table.Column<string>(type: "TEXT", nullable: true),
                    hyperdriveRating = table.Column<double>(type: "REAL", nullable: false),
                    starshipClass = table.Column<string>(type: "TEXT", nullable: true),
                    created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    edited = table.Column<DateTime>(type: "TEXT", nullable: false),
                    cargoCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    consumables = table.Column<string>(type: "TEXT", nullable: true),
                    costInCredits = table.Column<int>(type: "INTEGER", nullable: false),
                    crew = table.Column<string>(type: "TEXT", nullable: true),
                    length = table.Column<string>(type: "TEXT", nullable: true),
                    manufacturer = table.Column<string>(type: "TEXT", nullable: true),
                    model = table.Column<string>(type: "TEXT", nullable: true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    passengers = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Starship", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    vehicleClass = table.Column<string>(type: "TEXT", nullable: true),
                    created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    edited = table.Column<DateTime>(type: "TEXT", nullable: false),
                    cargoCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    consumables = table.Column<string>(type: "TEXT", nullable: true),
                    costInCredits = table.Column<int>(type: "INTEGER", nullable: false),
                    crew = table.Column<string>(type: "TEXT", nullable: true),
                    length = table.Column<string>(type: "TEXT", nullable: true),
                    manufacturer = table.Column<string>(type: "TEXT", nullable: true),
                    model = table.Column<string>(type: "TEXT", nullable: true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    passengers = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FilmCharacter",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "INTEGER", nullable: false),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmCharacter", x => new { x.FilmId, x.CharacterId });
                    table.ForeignKey(
                        name: "FK_FilmCharacter_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmCharacter_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmStarship",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "INTEGER", nullable: false),
                    StarshipId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmStarship", x => new { x.FilmId, x.StarshipId });
                    table.ForeignKey(
                        name: "FK_FilmStarship_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmPlanet",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlanetId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmPlanet", x => new { x.FilmId, x.PlanetId });
                    table.ForeignKey(
                        name: "FK_FilmPlanet_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmPlanet_Planet_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planet",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanetCharacter",
                columns: table => new
                {
                    planetId = table.Column<int>(type: "INTEGER", nullable: false),
                    characterId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanetCharacter", x => new { x.planetId, x.characterId });
                    table.ForeignKey(
                        name: "FK_PlanetCharacter_Planet_planetId",
                        column: x => x.planetId,
                        principalTable: "Planet",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmSpecies",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "INTEGER", nullable: false),
                    SpeciesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmSpecies", x => new { x.FilmId, x.SpeciesId });
                    table.ForeignKey(
                        name: "FK_FilmSpecies_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmSpecies_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeciesCharacter",
                columns: table => new
                {
                    speciesId = table.Column<int>(type: "INTEGER", nullable: false),
                    characterId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeciesCharacter", x => new { x.speciesId, x.characterId });
                    table.ForeignKey(
                        name: "FK_SpeciesCharacter_Character_characterId",
                        column: x => x.characterId,
                        principalTable: "Character",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpeciesCharacter_Species_speciesId",
                        column: x => x.speciesId,
                        principalTable: "Species",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeciesEyeColor",
                columns: table => new
                {
                    speciesId = table.Column<int>(type: "INTEGER", nullable: false),
                    eyeColor = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeciesEyeColor", x => new { x.speciesId, x.eyeColor });
                    table.ForeignKey(
                        name: "FK_SpeciesEyeColor_Species_speciesId",
                        column: x => x.speciesId,
                        principalTable: "Species",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeciesHairColor",
                columns: table => new
                {
                    speciesId = table.Column<int>(type: "INTEGER", nullable: false),
                    hairColor = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeciesHairColor", x => new { x.speciesId, x.hairColor });
                    table.ForeignKey(
                        name: "FK_SpeciesHairColor_Species_speciesId",
                        column: x => x.speciesId,
                        principalTable: "Species",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeciesSkinColor",
                columns: table => new
                {
                    speciesId = table.Column<int>(type: "INTEGER", nullable: false),
                    skinColor = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeciesSkinColor", x => new { x.speciesId, x.skinColor });
                    table.ForeignKey(
                        name: "FK_SpeciesSkinColor_Species_speciesId",
                        column: x => x.speciesId,
                        principalTable: "Species",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StarshipCharacter",
                columns: table => new
                {
                    starshipId = table.Column<int>(type: "INTEGER", nullable: false),
                    characterId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarshipCharacter", x => new { x.starshipId, x.characterId });
                    table.ForeignKey(
                        name: "FK_StarshipCharacter_Character_characterId",
                        column: x => x.characterId,
                        principalTable: "Character",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StarshipCharacter_Starship_starshipId",
                        column: x => x.starshipId,
                        principalTable: "Starship",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmVehicle",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "INTEGER", nullable: false),
                    VehicleId = table.Column<int>(type: "INTEGER", nullable: false),
                    Starshipid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmVehicle", x => new { x.FilmId, x.VehicleId });
                    table.ForeignKey(
                        name: "FK_FilmVehicle_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmVehicle_Starship_Starshipid",
                        column: x => x.Starshipid,
                        principalTable: "Starship",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FilmVehicle_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleCharacter",
                columns: table => new
                {
                    vehicleId = table.Column<int>(type: "INTEGER", nullable: false),
                    characterId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleCharacter", x => new { x.vehicleId, x.characterId });
                    table.ForeignKey(
                        name: "FK_VehicleCharacter_Character_characterId",
                        column: x => x.characterId,
                        principalTable: "Character",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleCharacter_Vehicle_vehicleId",
                        column: x => x.vehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmCharacter_CharacterId",
                table: "FilmCharacter",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmPlanet_PlanetId",
                table: "FilmPlanet",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmSpecies_SpeciesId",
                table: "FilmSpecies",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmVehicle_Starshipid",
                table: "FilmVehicle",
                column: "Starshipid");

            migrationBuilder.CreateIndex(
                name: "IX_FilmVehicle_VehicleId",
                table: "FilmVehicle",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeciesCharacter_characterId",
                table: "SpeciesCharacter",
                column: "characterId");

            migrationBuilder.CreateIndex(
                name: "IX_StarshipCharacter_characterId",
                table: "StarshipCharacter",
                column: "characterId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleCharacter_characterId",
                table: "VehicleCharacter",
                column: "characterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmCharacter");

            migrationBuilder.DropTable(
                name: "FilmPlanet");

            migrationBuilder.DropTable(
                name: "FilmSpecies");

            migrationBuilder.DropTable(
                name: "FilmStarship");

            migrationBuilder.DropTable(
                name: "FilmVehicle");

            migrationBuilder.DropTable(
                name: "PlanetCharacter");

            migrationBuilder.DropTable(
                name: "SpeciesCharacter");

            migrationBuilder.DropTable(
                name: "SpeciesEyeColor");

            migrationBuilder.DropTable(
                name: "SpeciesHairColor");

            migrationBuilder.DropTable(
                name: "SpeciesSkinColor");

            migrationBuilder.DropTable(
                name: "StarshipCharacter");

            migrationBuilder.DropTable(
                name: "VehicleCharacter");

            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "Planet");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Starship");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
