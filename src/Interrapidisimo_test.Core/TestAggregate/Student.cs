using System.Text.Json.Serialization;
using Ardalis.GuardClauses;
using Interrapidisimo_test.SharedKernel;
using Interrapidisimo_test.SharedKernel.Interfaces;

namespace Interrapidisimo_test.Core.TestAggregate;

public class Student : EntityBase, IAggregateRoot
{
  public string Name { get; set; }
  public CreditsProgramEnum CreditProgram { get; set; }
  public int TotalCredits { get; set; } = 0;
  public int RegisteredSubjets { get; set; } = 0;
  [JsonIgnore]
  public virtual ICollection<SelectedSubject>? SelectedSubjects { get;set; }

  public Student(string name)
  {
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
    TotalCredits = 0;
    RegisteredSubjets = 0;
    Random random = new Random();
    CreditProgram = (CreditsProgramEnum)random.Next(1, 6);
  }

  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }

  public void SelectSubject(Guid subjectId, Guid professorId)
  {
    RegisteredSubjets++;
    SelectedSubjects ??= new List<SelectedSubject>();
    SelectedSubjects!.Add(new SelectedSubject(Id,subjectId, professorId));
  }
}
