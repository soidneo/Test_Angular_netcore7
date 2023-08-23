using Ardalis.Specification;

namespace Interrapidisimo_test.Core.TestAggregate.Specifications;
public class SubjectSelectedbyIdListpec : Specification<SelectedSubject>, ISingleResultSpecification
{
  public SubjectSelectedbyIdListpec(Guid studentId, IEnumerable<SelectedSubject> SelectedSubjects)
  {
    var filteredSubjectIds = SelectedSubjects
        .Where(subject => subject.StudentId == studentId)
        .Select(subject => subject.SubjectId)
        .ToList();

    Query
        .Where(subject => filteredSubjectIds.Contains(subject.SubjectId))
        .Include(subject => subject.Student)
        .Include(subject => subject.Subject)
        .Include(subject => subject.Professor);
  }
}
