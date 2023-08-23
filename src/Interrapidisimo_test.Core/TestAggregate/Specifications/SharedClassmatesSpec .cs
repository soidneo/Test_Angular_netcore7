using Ardalis.Specification;

namespace Interrapidisimo_test.Core.TestAggregate.Specifications;
public class SharedClassmatesSpec : Specification<Student>, ISingleResultSpecification
{
  public SharedClassmatesSpec(Guid studentId)
  {
    Query
        .Include(student => student.SelectedSubjects!)
            .ThenInclude(selectedSubject => selectedSubject.Professor)
        .Include(student => student.SelectedSubjects!)
            .ThenInclude(professor => professor.Subject!)
        .Include(student => student.SelectedSubjects!)
            .ThenInclude(e => e.Subject)
        .Where(student =>
            student.Id != studentId &&
            student.SelectedSubjects!.Any(ss1 =>
                student.SelectedSubjects!.Any(ss2 =>
                    ss1.Subject!.Id == ss2.Subject!.Id)));


    //Query
    //   .Where(student =>
    //       student.Id != studentId &&
    //       student.SelectedSubjects!.Any(ss1 =>
    //           student.SelectedSubjects!.Any(ss2 =>
    //               ss1.Subject!.Id == ss2.Subject!.Id &&
    //               ss1.Professor!.Id != ss2.Professor!.Id))).Include(student => student.SelectedSubjects!)
    //    .ThenInclude(e => e.Subject)
    //    .Include(student => student.SelectedSubjects!)
    //    .ThenInclude(e => e.Professor);



    //Query
    //    .Include(student => student.SelectedSubjects!)
    //        .ThenInclude(selectedSubject => selectedSubject.Professor)
    //    .Where(student =>
    //        student.Id != student.Id &&
    //        student.SelectedSubjects!.Any(ss1 =>
    //            student.SelectedSubjects!.Any(ss2 =>
    //                ss1.Subject!.Id == ss2.Subject!.Id
    //                && ss1.Professor!.Id != ss2.Professor!.Id)))
    //    .Include(student => student.SelectedSubjects!)
    //    .ThenInclude(e => e.Subject)
    //    .Include(student => student.SelectedSubjects!)
    //    .ThenInclude(e => e.Professor);
  }
}
