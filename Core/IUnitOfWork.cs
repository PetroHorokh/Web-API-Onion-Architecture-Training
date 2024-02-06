using Core.Models;
using Core.Repositories;

namespace Core;

public interface IUnitOfWork : IDisposable
{
    IOwnerRepository Owners { get; }

    IAccountRepository Accounts { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}