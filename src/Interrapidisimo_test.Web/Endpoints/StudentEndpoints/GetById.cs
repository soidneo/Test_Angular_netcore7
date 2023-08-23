using FastEndpoints;
using Interrapidisimo_test.Core.TestAggregate;
using Interrapidisimo_test.Core.TestAggregate.Specifications;
using Interrapidisimo_test.SharedKernel.Interfaces;

namespace Interrapidisimo_test.Web.Endpoints.StudentEndpoints;
public class GetById : Endpoint<GetStudentByIdRequest, StudentRecord>
{
  private readonly IRepository<Student> _repository;

  public GetById(IRepository<Student> repository)
  {
    _repository = repository;
  }

  public override void Configure()
  {
    Get(GetStudentByIdRequest.Route);
    AllowAnonymous();
    Options(x => x
      .WithTags("StudentEndpoints"));
  }
  public override async Task HandleAsync(GetStudentByIdRequest request,
    CancellationToken cancellationToken)
  {
    var spec = new StudentByIdSpec(request.StudentId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var response = new StudentRecord(entity.Id, entity.Name, entity.SelectedSubjects!.ToList());

    await SendAsync(response, cancellation: cancellationToken);
  }
}
