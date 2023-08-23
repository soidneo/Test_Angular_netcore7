using FastEndpoints;
using Interrapidisimo_test.Core.TestAggregate;
using Interrapidisimo_test.SharedKernel.Interfaces;

namespace Interrapidisimo_test.Web.Endpoints.StudentEndpoints;
public class Create : Endpoint<CreateStudentRequest, CreateStudentResponse>
{
  private readonly IRepository<Student> _repository;

  public Create(IRepository<Student> repository)
  {
    _repository = repository;
  }

  public override void Configure()
  {
    Post(CreateStudentRequest.Route);
    AllowAnonymous();
    Options(x => x
      .WithTags("StudentEndpoints"));
  }
  public override async Task HandleAsync(
    CreateStudentRequest request,
    CancellationToken cancellationToken)
  {
    if (request.Name == null)
    {
      ThrowError("Name is required");
    }

    var newStudent = new Student(request.Name);
    var createdItem = await _repository.AddAsync(newStudent, cancellationToken);
    var response = new CreateStudentResponse
    (
      id: createdItem.Id,
      name: createdItem.Name
    );

    await SendAsync(response, cancellation: cancellationToken);
  }
}
