using Interrapidisimo_test.Core.TestAggregate;

namespace Interrapidisimo_test.Web.Endpoints.SubjectEndpoints;

public record SubjectRecord(Guid Id, string Name)
{
  public static implicit operator SubjectRecord(Subject v)
       => new(v.Id,
              v.Name);
}
