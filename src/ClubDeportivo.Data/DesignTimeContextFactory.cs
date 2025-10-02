using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace ClubDeportivo.Data;

public class DesignTimeContextFactory : IDesignTimeDbContextFactory<ClubContext>
{
	public ClubContext CreateDbContext(string[] args)
	{
		// Usar variable de entorno: CLUB_CONN
		var cs = Environment.GetEnvironmentVariable("CLUB_CONN");
		if (string.IsNullOrWhiteSpace(cs))
			throw new InvalidOperationException(
				"Definí la cadena de conexión en la variable de entorno CLUB_CONN para generar migraciones.");

		var builder = new DbContextOptionsBuilder<ClubContext>();
		builder.UseMySql(cs, ServerVersion.AutoDetect(cs));
		return new ClubContext(builder.Options);
	}
}
