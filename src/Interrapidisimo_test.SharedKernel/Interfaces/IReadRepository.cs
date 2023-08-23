using Ardalis.Specification;

namespace Interrapidisimo_test.SharedKernel.Interfaces;
public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
