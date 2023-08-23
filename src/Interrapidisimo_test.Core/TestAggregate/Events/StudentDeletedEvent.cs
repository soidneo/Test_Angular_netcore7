using Interrapidisimo_test.SharedKernel;

namespace Interrapidisimo_test.Core.StudentAggregate.Events;
public class StudentDeletedEvent : DomainEventBase
{
  public int StudentId { get; set; }

  public StudentDeletedEvent(int contributorId)
  {
    StudentId = contributorId;
  }
}
