using FastEndpoints;
using Interrapidisimo_test.Core.TestAggregate;
using Interrapidisimo_test.SharedKernel.Interfaces;

namespace Interrapidisimo_test.Web.Endpoints.ProfessorEndpoints;
public class List : EndpointWithoutRequest<ProfessorListResponse>
{
  private readonly IRepository<Professor> _repository;

  public List(IRepository<Professor> repository)
  {
    _repository = repository;
  }

  public override void Configure()
  {
    Get("/Professors");
    AllowAnonymous();
    Options(x => x
      .WithTags("ProfessorEndpoints"));
  }
  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var subjects = await _repository.ListAsync(cancellationToken);
    var response = new ProfessorListResponse()
    {
      Professors = subjects
        .Select(subject => new ProfessorRecord(subject.Id, subject.Name))
        .ToList()
    };

    await SendAsync(response, cancellation: cancellationToken);
  }
}
