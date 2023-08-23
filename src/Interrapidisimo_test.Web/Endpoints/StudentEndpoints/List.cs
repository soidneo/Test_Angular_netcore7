using FastEndpoints;
using Interrapidisimo_test.Core.TestAggregate;
using Interrapidisimo_test.Core.TestAggregate.Specifications;
using Interrapidisimo_test.SharedKernel.Interfaces;

namespace Interrapidisimo_test.Web.Endpoints.StudentEndpoints;
public class List : EndpointWithoutRequest<StudentListResponse>
{
  private readonly IRepository<Student> _repository;

  public List(IRepository<Student> repository)
  {
    _repository = repository;
  }

  public override void Configure()
  {
    Get("/Students");
    AllowAnonymous();
    Options(x => x
      .WithTags("StudentEndpoints"));
  }
  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var spec = new StudentListpec();
    var students = await _repository.ListAsync(spec, cancellationToken);
    var response = new StudentListResponse()
    {
      Students = students
        .Select(student => new StudentRecord(student.Id, student.Name,student.SelectedSubjects!.ToList()))
        .ToList()
    };

    await SendAsync(response, cancellation: cancellationToken);
  }
}
