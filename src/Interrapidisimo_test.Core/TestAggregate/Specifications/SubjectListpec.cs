using Ardalis.Specification;

namespace Interrapidisimo_test.Core.TestAggregate.Specifications;
public class SubjectListpec : Specification<Subject>, ISingleResultSpecification
{
  public SubjectListpec()
  {
    Query
        .Include(student => student.SelectedSubject);
  }
}
