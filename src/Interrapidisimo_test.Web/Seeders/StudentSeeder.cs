using Interrapidisimo_test.Core.TestAggregate;
using Interrapidisimo_test.Infrastructure.Data;

namespace Interrapidisimo_test.Web.Seeders;

public class StudentSeeder
{
  public static void Seed(AppDbContext dbContext)
  {
    if (!dbContext.Estudiantes.Any())
    {
      dbContext.Estudiantes.AddRange(
          new Student("Juan"),
          new Student("María"),
          new Student("Luis"),
          new Student("Ana"),
          new Student("Carlos")
      );
      dbContext.SaveChanges();
    }
  }
}
