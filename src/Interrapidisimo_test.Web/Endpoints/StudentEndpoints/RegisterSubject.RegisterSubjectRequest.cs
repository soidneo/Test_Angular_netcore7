using System.ComponentModel.DataAnnotations;

namespace Interrapidisimo_test.Web.Endpoints.StudentEndpoints;
public class RegisterSubjectRequest
{
  public const string Route = "/registerSubject";
  [Required]
  public Guid StudentId { get; set; } = Guid.Empty;
  [Required]
  public Guid SubjectId { get; set; } = Guid.Empty;
  [Required]
  public Guid ProfessorId { get; set; } = Guid.Empty;
}
