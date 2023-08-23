using Interrapidisimo_test.SharedKernel;

namespace Interrapidisimo_test.Core.ContributorAggregate.Events;
public class ContributorDeletedEvent : DomainEventBase
{
  public int ContributorId { get; set; }

  public ContributorDeletedEvent(int contributorId)
  {
    ContributorId = contributorId;
  }
}
