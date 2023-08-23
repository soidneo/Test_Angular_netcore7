using Ardalis.Specification;

namespace Interrapidisimo_test.Core.ProjectAggregate.Specifications;
public class ProjectByIdWithItemsSpec : Specification<Project>, ISingleResultSpecification
{
  public ProjectByIdWithItemsSpec(Guid projectId)
  {
    Query
        .Where(project => project.Id == projectId)
        .Include(project => project.Items);
  }
}
