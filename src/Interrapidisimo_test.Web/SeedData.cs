using Interrapidisimo_test.Infrastructure.Data;
using Interrapidisimo_test.Web.Seeders;
using Microsoft.EntityFrameworkCore;

namespace Interrapidisimo_test.Web;
public static class SeedData
{

  public static void Initialize(IServiceProvider serviceProvider)
  {
    using var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null);

    if (!dbContext.Materias.Any()) SubjectSeeder.Seed(dbContext);
    if (!dbContext.Profesores.Any()) ProfessorSeeder.Seed(dbContext);
    if (!dbContext.Estudiantes.Any()) StudentSeeder.Seed(dbContext);
    if (!dbContext.MateriasSeleccionadas.Any()) SelectedSubjectSeeder.Seed(dbContext);
  }
}
