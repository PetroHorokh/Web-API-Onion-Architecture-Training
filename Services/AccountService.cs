using Core;
using Core.Models;
using Core.Services.Abstract;

namespace Services;

public class AccountService(IUnitOfWork unitOfWork) : IAccountService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Account>> GetAllAccountsAsync(
        CancellationToken cancellationToken = default) =>
        await _unitOfWork.Accounts.GetAllAsync(
            cancellationToken);

    public async Task<IEnumerable<Account>> GetAccountsByAccountTypeAsync(
        string accountType,
        CancellationToken cancellationToken = default) =>
        await _unitOfWork.Accounts.GetByConditionAsync(
            account => account.AccountType == accountType, 
            cancellationToken);

    public async Task<IEnumerable<Account>> GetAccountsByOwnerIdAsync(
        Guid ownerId,
        CancellationToken cancellationToken = default) =>
        await _unitOfWork.Accounts.GetByConditionAsync(
            account => account.OwnerId == ownerId, 
            cancellationToken);

    public async Task<Account?> GetAccountByIdAsync(
        Guid accountId,
        CancellationToken cancellationToken = default) =>
        (await _unitOfWork.Accounts.GetByConditionAsync(
            account => account.Id == accountId,
            cancellationToken))
        .FirstOrDefault();
}