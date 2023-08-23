using System.Text.Json.Serialization;
using Ardalis.GuardClauses;
using Interrapidisimo_test.SharedKernel;
using Interrapidisimo_test.SharedKernel.Interfaces;

namespace Interrapidisimo_test.Core.TestAggregate;
public class Subject : EntityBase, IAggregateRoot
{
  public string Name { get; set; } = string.Empty;
  public int Credits { get; set; }
  [JsonIgnore]
  public virtual ICollection<SelectedSubject>? SelectedSubject { get; set; }

  public Subject(string name, int credits)
  {
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
    Credits = credits;
  }
}
