using Ardalis.Specification;
using Interrapidisimo_test.Core.ContributorAggregate;

namespace Interrapidisimo_test.Core.ProjectAggregate.Specifications;
public class ContributorByIdSpec : Specification<Contributor>, ISingleResultSpecification
{
  public ContributorByIdSpec(Guid contributorId)
  {
    Query
        .Where(contributor => contributor.Id == contributorId);
  }
}
