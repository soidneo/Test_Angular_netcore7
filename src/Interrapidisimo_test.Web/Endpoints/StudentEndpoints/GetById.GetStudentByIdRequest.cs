namespace Interrapidisimo_test.Web.Endpoints.StudentEndpoints;

public class GetStudentByIdRequest
{
  public const string Route = "/Students/{StudentId:guid}";
  public static string BuildRoute(Guid contributorId) => Route.Replace("{StudentId:guid}", contributorId.ToString());

  public Guid StudentId { get; set; }
}
