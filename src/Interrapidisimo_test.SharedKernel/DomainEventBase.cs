using MediatR;

namespace Interrapidisimo_test.SharedKernel;
public abstract class DomainEventBase : INotification
{
  public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}
