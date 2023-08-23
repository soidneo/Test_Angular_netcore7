using Ardalis.Specification;

namespace Interrapidisimo_test.Core.TestAggregate.Specifications;
public class StudentByIdSpec : Specification<Student>, ISingleResultSpecification
{
  public StudentByIdSpec(Guid id)
  {
    Query
        .Include(student => student.Id == id);
  }
}
