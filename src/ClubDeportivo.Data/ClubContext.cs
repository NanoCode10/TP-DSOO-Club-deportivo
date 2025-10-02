using ClubDeportivo.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClubDeportivo.Data;

public class ClubContext : DbContext
{
    public ClubContext(DbContextOptions<ClubContext> options) : base(options) { }

    public DbSet<Persona> Personas => Set<Persona>();
    public DbSet<Socio> Socios => Set<Socio>();
    public DbSet<NoSocio> NoSocios => Set<NoSocio>();
    public DbSet<Carnet> Carnets => Set<Carnet>();
    public DbSet<Cuota> Cuotas => Set<Cuota>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Mapeo mínimo (ajustaremos 1:1 al UML cuando entremos a datos)
        modelBuilder.Entity<Persona>(b =>
        {
            b.HasKey(p => p.Id);
            b.Property(p => p.Dni).IsRequired().HasMaxLength(20);
            b.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
            b.Property(p => p.Apellido).IsRequired().HasMaxLength(100);
        });

        modelBuilder.Entity<Socio>(b =>
        {
            b.HasMany(s => s.Cuotas).WithOne().HasForeignKey(c => c.SocioId);
            b.HasOne(s => s.Carnet).WithOne().HasForeignKey<Carnet>(c => c.SocioId);
        });

        modelBuilder.Entity<Carnet>(b => b.HasKey(c => c.Id));
        modelBuilder.Entity<Cuota>(b => b.HasKey(c => c.Id));
    }
}
