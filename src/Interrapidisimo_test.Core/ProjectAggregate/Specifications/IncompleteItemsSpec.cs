using Ardalis.Specification;

namespace Interrapidisimo_test.Core.ProjectAggregate.Specifications;
public class IncompleteItemsSpec : Specification<ToDoItem>
{
  public IncompleteItemsSpec()
  {
    Query.Where(item => !item.IsDone);
  }
}
