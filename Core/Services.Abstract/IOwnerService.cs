using Core.Models;

namespace Core.Services.Abstract;

public interface IOwnerService
{
    Task<IEnumerable<Owner>> GetAllOwnersAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<Owner>> GetOwnersByNameAsync(string name, CancellationToken cancellationToken = default);

    Task<IEnumerable<Owner>> GetOwnersByAddressAsync(string address, CancellationToken cancellationToken = default);

    Task<IEnumerable<Owner>> GetOwnersByDateOfBirthAsync(DateTime dateOfBirth, CancellationToken cancellationToken = default);

    Task<Owner?> GetOwnerByAccountIdAsync(Guid accountId, CancellationToken cancellationToken = default);

    Task<Owner?> GetOwnerByIdAsync(Guid ownerId, CancellationToken cancellationToken = default);

    Task CreateOwnerAsync(Owner owner, CancellationToken cancellationToken = default);

    Task<Owner?> DeleteOwnerAsync(Guid ownerId, CancellationToken cancellationToken = default);

    Task<Owner?> UpdateOwnerAsync(Guid ownerId, Owner ownerUpdate, CancellationToken cancellationToken = default);
}