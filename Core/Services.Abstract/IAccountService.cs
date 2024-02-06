using Core.Models;

namespace Core.Services.Abstract;

public interface IAccountService
{
    Task<IEnumerable<Account>> GetAllAccountsAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<Account>> GetAccountsByAccountTypeAsync(string accountType, CancellationToken cancellationToken = default);

    Task<IEnumerable<Account>> GetAccountsByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default);

    Task<Account?> GetAccountByIdAsync(Guid accountId, CancellationToken cancellationToken = default);
}