using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ClubDeportivo.Data;

public class DesignTimeContextFactory : IDesignTimeDbContextFactory<ClubContext>
{
    public ClubContext CreateDbContext(string[] args)
    {
        var cs = Environment.GetEnvironmentVariable("CLUB_CONN")
                 ?? "Server=localhost;Database=club_deportivo;User Id=root;Password=;TreatTinyAsBoolean=false;";
        var options = new DbContextOptionsBuilder<ClubContext>()
            .UseMySql(cs, ServerVersion.AutoDetect(cs))
            .Options;
        return new ClubContext(options);
    }
}
