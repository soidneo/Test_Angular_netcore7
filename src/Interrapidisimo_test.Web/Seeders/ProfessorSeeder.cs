using Interrapidisimo_test.Core.TestAggregate;
using Interrapidisimo_test.Infrastructure.Data;

namespace Interrapidisimo_test.Web.Seeders;

public class ProfessorSeeder
{
  public static void Seed(AppDbContext dbContext)
  {
    if (!dbContext.Profesores.Any())
    {
      dbContext.Profesores.AddRange(
          new Professor("Juan Pérez"),
          new Professor("María González"),
          new Professor("Luis Rodríguez"),
          new Professor("Ana Martínez"),
          new Professor("Carlos Sánchez")
      );
      dbContext.SaveChanges();
    }
  }
}
