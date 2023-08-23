namespace Interrapidisimo_test.Web.Endpoints.StudentEndpoints;

public class CreateStudentResponse
{
  public CreateStudentResponse(Guid id, string name)
  {
    Id = id;
    Name = name;
  }
  public Guid Id { get; set; }
  public string Name { get; set; }
}
