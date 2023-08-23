using FastEndpoints;
using Interrapidisimo_test.Core.TestAggregate;
using Interrapidisimo_test.SharedKernel.Interfaces;

namespace Interrapidisimo_test.Web.Endpoints.SubjectEndpoints;
public class List : EndpointWithoutRequest<SubjectListResponse>
{
  private readonly IRepository<Subject> _repository;

  public List(IRepository<Subject> repository)
  {
    _repository = repository;
  }

  public override void Configure()
  {
    Get("/Subjects");
    AllowAnonymous();
    Options(x => x
      .WithTags("SubjectEndpoints"));
  }
  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var subjects = await _repository.ListAsync(cancellationToken);
    var response = new SubjectListResponse()
    {
      Subjects = subjects
        .Select(subject => new SubjectRecord(subject.Id, subject.Name))
        .ToList()
    };

    await SendAsync(response, cancellation: cancellationToken);
  }
}
