namespace Interrapidisimo_test.Web.Endpoints.StudentEndpoints;

public class StudentRequest
{
  public const string Route = "/FilteredStudents/{StudentId:guid}";
  public static string BuildRoute(Guid contributorId) => Route.Replace("{StudentId:guid}", contributorId.ToString());

  public Guid StudentId { get; set; }
}
