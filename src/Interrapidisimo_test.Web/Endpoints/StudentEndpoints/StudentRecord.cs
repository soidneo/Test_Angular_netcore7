using Interrapidisimo_test.Core.TestAggregate;

namespace Interrapidisimo_test.Web.Endpoints.StudentEndpoints;

public record StudentRecord(Guid Id, string Name, List<SelectedSubject>? RegisteredSubjects)
{
  public static implicit operator StudentRecord(Student v)
       => new(v.Id,
              v.Name,
              v.SelectedSubjects!.ToList());
}
