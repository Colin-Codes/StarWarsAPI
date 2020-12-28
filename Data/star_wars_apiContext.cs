using Microsoft.EntityFrameworkCore;
using star_wars_api.Models;

namespace star_wars_api.Data
{
    public class star_wars_apiContext : DbContext
    {
        public star_wars_apiContext (DbContextOptions<star_wars_apiContext> options) : base(options) {
        }

        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>().HasKey(p => new { p.id });
            modelBuilder.Entity<FilmCharacter>().HasKey(p => new { p.FilmId, p.CharacterId });
            modelBuilder.Entity<FilmPlanet>().HasKey(p => new { p.FilmId, p.PlanetId });
            modelBuilder.Entity<FilmSpecies>().HasKey(p => new { p.FilmId, p.SpeciesId });
            modelBuilder.Entity<FilmStarship>().HasKey(p => new { p.FilmId, p.StarshipId });
            modelBuilder.Entity<FilmVehicle>().HasKey(p => new { p.FilmId, p.VehicleId });
            modelBuilder.Entity<Planet>().HasKey(p => new { p.id });
            modelBuilder.Entity<PlanetCharacter>().HasKey(p => new { p.planetId, p.characterId });
            modelBuilder.Entity<Character>().HasKey(p => new { p.id });
            modelBuilder.Entity<Species>().HasKey(p => new { p.id });
            modelBuilder.Entity<SpeciesEyeColor>().HasKey(p => new { p.speciesId, p.eyeColor });
            modelBuilder.Entity<SpeciesHairColor>().HasKey(p => new { p.speciesId, p.hairColor });
            modelBuilder.Entity<SpeciesSkinColor>().HasKey(p => new { p.speciesId, p.skinColor });
            modelBuilder.Entity<SpeciesCharacter>().HasKey(p => new { p.speciesId, p.characterId });
            modelBuilder.Entity<Vehicle>().HasKey(p => new { p.id });
            modelBuilder.Entity<VehicleCharacter>().HasKey(p => new { p.vehicleId, p.characterId });
            modelBuilder.Entity<Starship>().HasKey(p => new { p.id });
            modelBuilder.Entity<StarshipCharacter>().HasKey(p => new { p.starshipId, p.characterId });
        }

        public DbSet<Film> Film { get; set; }

        public DbSet<FilmCharacter> FilmCharacter { get; set; }

        public DbSet<FilmPlanet> FilmPlanet { get; set; }

        public DbSet<FilmSpecies> FilmSpecies { get; set; }

        public DbSet<FilmStarship> FilmStarship { get; set; }

        public DbSet<FilmVehicle> FilmVehicle { get; set; }

        public DbSet<Planet> Planet { get; set; }

        public DbSet<PlanetCharacter> PlanetCharacter { get; set; }

        public DbSet<Character> Character { get; set; }

        public DbSet<Species> Species { get; set; }

        public DbSet<SpeciesEyeColor> SpeciesEyeColor { get; set; }

        public DbSet<SpeciesHairColor> SpeciesHairColor { get; set; }

        public DbSet<SpeciesSkinColor> SpeciesSkinColor { get; set; }

        public DbSet<SpeciesCharacter> SpeciesCharacter { get; set; }

        public DbSet<Vehicle> Vehicle { get; set; }

        public DbSet<VehicleCharacter> VehicleCharacter { get; set; }

        public DbSet<Starship> Starship { get; set; }

        public DbSet<StarshipCharacter> StarshipCharacter { get; set; }
    }
}