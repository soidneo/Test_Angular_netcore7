using Ardalis.GuardClauses;
using Interrapidisimo_test.SharedKernel;
using Interrapidisimo_test.SharedKernel.Interfaces;

namespace Interrapidisimo_test.Core.ContributorAggregate;
public class Contributor : EntityBase, IAggregateRoot
{
  public string Name { get; private set; }

  public Contributor(string name)
  {
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
  }

  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }
}
