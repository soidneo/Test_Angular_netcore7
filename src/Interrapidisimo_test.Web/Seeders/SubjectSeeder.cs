using Interrapidisimo_test.Core.TestAggregate;
using Interrapidisimo_test.Infrastructure.Data;

namespace Interrapidisimo_test.Web.Seeders;

public class SubjectSeeder
{
  public static void Seed(AppDbContext dbContext)
  {
    if (!dbContext.Materias.Any())
    {
      dbContext.Materias.AddRange(
          new Subject("Matemáticas", 3),
          new Subject("Física", 3),
          new Subject("Química", 3),
          new Subject("Biología", 3),
          new Subject("Historia", 3),
          new Subject("Literatura", 3),
          new Subject("Geografía", 3),
          new Subject("Arte", 3),
          new Subject("Educación Física", 3),
          new Subject("Informática", 3)
      );
      dbContext.SaveChanges();
    }
  }
}
