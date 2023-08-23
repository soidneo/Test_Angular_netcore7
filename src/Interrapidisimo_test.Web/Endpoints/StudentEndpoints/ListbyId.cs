using FastEndpoints;
using Interrapidisimo_test.Core.TestAggregate;
using Interrapidisimo_test.Core.TestAggregate.Specifications;
using Interrapidisimo_test.SharedKernel.Interfaces;

namespace Interrapidisimo_test.Web.Endpoints.StudentEndpoints;
public class ListbyId : Endpoint<StudentRequest,StudentListResponse>
{
  private readonly IRepository<Student> _repository;

  public ListbyId(IRepository<Student> repository)
  {
    _repository = repository;
  }

  public override void Configure()
  {
    Get(StudentRequest.Route);
    AllowAnonymous();
    Options(x => x
      .WithTags("StudentEndpoints"));
  }
  public override async Task HandleAsync(StudentRequest request,
    CancellationToken cancellationToken)
  {
    var spec = new SharedClassmatesSpec(request.StudentId);
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
