using System.Text.Json.Serialization;
using Ardalis.GuardClauses;
using Interrapidisimo_test.SharedKernel;
using Interrapidisimo_test.SharedKernel.Interfaces;

namespace Interrapidisimo_test.Core.TestAggregate;
public class Professor : EntityBase, IAggregateRoot
{
  public string Name { get; set; } = string.Empty;
  [JsonIgnore]
  public virtual ICollection<SelectedSubject>? SelectedSubject { get; set; }
  public Professor(string name)
  {
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
  }
}
