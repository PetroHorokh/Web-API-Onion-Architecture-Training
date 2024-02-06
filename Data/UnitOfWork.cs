using Core;
using Core.Repositories;
using Data.Repositories;

namespace Data;

public class UnitOfWork(OnionDbContext context) : IUnitOfWork
{
    private OwnerRepository _ownerRepository;
    private AccountRepository _accountRepository;

    public IOwnerRepository Owners => _ownerRepository = _ownerRepository ?? new OwnerRepository(context);

    public IAccountRepository Accounts => _accountRepository = _accountRepository ?? new AccountRepository(context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await context
            .SaveChangesAsync(
                cancellationToken);

    public void Dispose()
    {
        context.Dispose();
    }
}