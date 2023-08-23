using Ardalis.Result;
using Interrapidisimo_test.Core.Interfaces;
using Interrapidisimo_test.Core.TestAggregate;
using Interrapidisimo_test.SharedKernel.Interfaces;
using MediatR;

namespace Interrapidisimo_test.Core.Services;
public class DeleteStudentService : IDeleteStudentService
{
  private readonly IRepository<Student> _repository;
  private readonly IMediator _mediator;

  public DeleteStudentService(IRepository<Student> repository, IMediator mediator)
  {
    _repository = repository;
    _mediator = mediator;
  }

  public async Task<Result> DeleteStudent(int contributorId)
  {
    var aggregateToDelete = await _repository.GetByIdAsync(contributorId);
    if (aggregateToDelete == null) return Result.NotFound();

    await _repository.DeleteAsync(aggregateToDelete);
    var domainEvent = new StudentDeletedEvent(contributorId);
    await _mediator.Publish(domainEvent);
    return Result.Success();
  }
}
