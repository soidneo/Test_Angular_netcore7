using Interrapidisimo_test.SharedKernel;

namespace Interrapidisimo_test.Core.ProjectAggregate.Events;
public class ToDoItemCompletedEvent : DomainEventBase
{
  public ToDoItem CompletedItem { get; set; }

  public ToDoItemCompletedEvent(ToDoItem completedItem)
  {
    CompletedItem = completedItem;
  }
}
