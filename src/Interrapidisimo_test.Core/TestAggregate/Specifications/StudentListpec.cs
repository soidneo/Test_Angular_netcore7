using Ardalis.Specification;

namespace Interrapidisimo_test.Core.TestAggregate.Specifications;
public class StudentListpec : Specification<Student>, ISingleResultSpecification
{
  public StudentListpec()
  {
    Query
        .Include(student => student.SelectedSubjects!)
        .ThenInclude(e => e.Subject)
        .Include(student => student.SelectedSubjects!)
        .ThenInclude(e => e.Professor);
  }
}
