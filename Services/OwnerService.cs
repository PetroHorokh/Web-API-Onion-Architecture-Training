using Core;
using Core.Models;
using Core.Services.Abstract;
using System.Net;

namespace Services;

public class OwnerService(IUnitOfWork unitOfWork) : IOwnerService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Owner>> GetAllOwnersAsync(
        CancellationToken cancellationToken = default) => 
        await _unitOfWork
            .Owners
            .GetAllAsync(
                cancellationToken);

    public async Task<IEnumerable<Owner>> GetOwnersByNameAsync(
        string name, 
        CancellationToken cancellationToken = default) => 
        await _unitOfWork
            .Owners
            .GetByConditionAsync(
                owner => owner.Name == name 
                ,cancellationToken);

    public async Task<IEnumerable<Owner>> GetOwnersByAddressAsync(
        string address, 
        CancellationToken cancellationToken = default) => 
        await _unitOfWork
            .Owners
            .GetByConditionAsync(
                owner => owner.Address == address, 
                cancellationToken);

    public async Task<IEnumerable<Owner>> GetOwnersByDateOfBirthAsync(
        DateTime dateOfBirth, 
        CancellationToken cancellationToken = default) =>
        await _unitOfWork
            .Owners
            .GetByConditionAsync(
                owner => owner.DateOfBirth == dateOfBirth, 
                cancellationToken);

    public async Task<Owner?> GetOwnerOfAccountAsync(
        Guid accountId, 
        CancellationToken cancellationToken = default)
    {
        var account =
            (await _unitOfWork
                .Accounts
                .GetByConditionAsync(
                    account => account.Id == accountId, 
                    cancellationToken))
            .FirstOrDefault();

        var owner = 
            (await _unitOfWork
                .Owners
                .GetByConditionAsync(
                    owner => owner.Id == account.OwnerId, 
                    cancellationToken))
            .FirstOrDefault();

        return owner;
    }

    public async Task<Owner?> GetOwnerByIdAsync(
        Guid ownerId, 
        CancellationToken cancellationToken = default) =>
        (await _unitOfWork
            .Owners
            .GetByConditionAsync(
                owner => owner.Id == ownerId, 
                cancellationToken))
        .FirstOrDefault();
}