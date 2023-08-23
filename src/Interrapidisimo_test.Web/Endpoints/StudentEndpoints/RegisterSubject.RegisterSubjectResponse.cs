using Interrapidisimo_test.Core.TestAggregate;

namespace Interrapidisimo_test.Web.Endpoints.StudentEndpoints;

public class RegisterSubjectResponse
{
  public RegisterSubjectResponse(Student student)
  {
    Student = student!;
  }
  public StudentRecord Student { get; set; }
}
