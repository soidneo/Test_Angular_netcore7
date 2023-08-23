using Interrapidisimo_test.Core.TestAggregate;

namespace Interrapidisimo_test.Web.Endpoints.ProfessorEndpoints;

public record ProfessorRecord(Guid Id, string Name)
{
  public static implicit operator ProfessorRecord(Professor v)
       => new(v.Id,
              v.Name);
}
