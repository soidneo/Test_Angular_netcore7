using System.Text.Json.Serialization;
using Ardalis.GuardClauses;
using Interrapidisimo_test.SharedKernel;
using Interrapidisimo_test.SharedKernel.Interfaces;

namespace Interrapidisimo_test.Core.TestAggregate;
public class SelectedSubject : EntityBase, IAggregateRoot
{
  public Guid StudentId { get; set; }
  public Guid SubjectId { get; set; }
  public Guid ProfessorId { get; set; }
  [JsonIgnore]
  public virtual Student? Student { get; set; }
  public virtual Subject? Subject { get; set; }
  public virtual Professor? Professor { get; set; }

  public SelectedSubject(Guid studentId, Guid subjectId, Guid professorId)
  {
    StudentId = Guard.Against.NullOrEmpty(studentId, nameof(studentId));
    SubjectId = Guard.Against.NullOrEmpty(subjectId, nameof(subjectId));
    ProfessorId = Guard.Against.NullOrEmpty(professorId, nameof(professorId));
  }
}
