using Microsoft.EntityFrameworkCore.Migrations;

namespace star_wars_api.Migrations
{
    public partial class changeToTransportNullables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmVehicle_Starship_Starshipid",
                table: "FilmVehicle");

            migrationBuilder.DropIndex(
                name: "IX_FilmVehicle_Starshipid",
                table: "FilmVehicle");

            migrationBuilder.DropColumn(
                name: "Starshipid",
                table: "FilmVehicle");

            migrationBuilder.AlterColumn<int>(
                name: "passengers",
                table: "Vehicle",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "length",
                table: "Vehicle",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "crew",
                table: "Vehicle",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "costInCredits",
                table: "Vehicle",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "cargoCapacity",
                table: "Vehicle",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "passengers",
                table: "Starship",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "length",
                table: "Starship",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "hyperdriveRating",
                table: "Starship",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<int>(
                name: "crew",
                table: "Starship",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "costInCredits",
                table: "Starship",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "cargoCapacity",
                table: "Starship",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_FilmStarship_StarshipId",
                table: "FilmStarship",
                column: "StarshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmStarship_Starship_StarshipId",
                table: "FilmStarship",
                column: "StarshipId",
                principalTable: "Starship",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmStarship_Starship_StarshipId",
                table: "FilmStarship");

            migrationBuilder.DropIndex(
                name: "IX_FilmStarship_StarshipId",
                table: "FilmStarship");

            migrationBuilder.AlterColumn<int>(
                name: "passengers",
                table: "Vehicle",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "length",
                table: "Vehicle",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "crew",
                table: "Vehicle",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "costInCredits",
                table: "Vehicle",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "cargoCapacity",
                table: "Vehicle",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "passengers",
                table: "Starship",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "length",
                table: "Starship",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "hyperdriveRating",
                table: "Starship",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "crew",
                table: "Starship",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "costInCredits",
                table: "Starship",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "cargoCapacity",
                table: "Starship",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Starshipid",
                table: "FilmVehicle",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FilmVehicle_Starshipid",
                table: "FilmVehicle",
                column: "Starshipid");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmVehicle_Starship_Starshipid",
                table: "FilmVehicle",
                column: "Starshipid",
                principalTable: "Starship",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
