using Microsoft.EntityFrameworkCore;
using ClubDeportivo.Core.Entities;

namespace ClubDeportivo.Data;

public class ClubContext : DbContext
{
    public ClubContext(DbContextOptions<ClubContext> options) : base(options) { }

    public DbSet<Socio> Socios => Set<Socio>();
    public DbSet<NoSocio> NoSocios => Set<NoSocio>();
    public DbSet<Cuota> Cuotas => Set<Cuota>();
    public DbSet<Carnet> Carnets => Set<Carnet>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Socio>().HasKey(x => x.IdSocio);
        modelBuilder.Entity<NoSocio>().HasKey(x => x.IdNoSocio);
        modelBuilder.Entity<Cuota>().HasKey(x => x.IdCuota);
        modelBuilder.Entity<Carnet>().HasKey(x => x.IdCarnet);

        // Herencia Persona -> Socio/NoSocio (TPT simple)
        modelBuilder.Entity<Persona>().HasKey(p => p.Dni);
        modelBuilder.Entity<Socio>().ToTable("Socio");
        modelBuilder.Entity<NoSocio>().ToTable("NoSocio");
        modelBuilder.Entity<Persona>().ToTable("Persona");

        base.OnModelCreating(modelBuilder);
    }
}
