using System.ComponentModel.DataAnnotations;

namespace Interrapidisimo_test.Web.Endpoints.StudentEndpoints;
public class CreateStudentRequest
{
  public const string Route = "/addStudent";

  [Required]
  public string? Name { get; set; }
}
