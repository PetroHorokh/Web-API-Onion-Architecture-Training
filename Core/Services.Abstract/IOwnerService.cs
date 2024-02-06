using Core.Models;

namespace Core.Services.Abstract;

public interface IOwnerService
{
    Task<IEnumerable<Owner>> GetAllOwnersAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<Owner>> GetOwnersByNameAsync(string name, CancellationToken cancellationToken = default);

    Task<IEnumerable<Owner>> GetOwnersByAddressAsync(string address, CancellationToken cancellationToken = default);

    Task<IEnumerable<Owner>> GetOwnersByDateOfBirthAsync(DateTime dateOfBirth, CancellationToken cancellationToken = default);

    Task<Owner?> GetOwnerOfAccountAsync(Guid accountId, CancellationToken cancellationToken = default);

    Task<Owner?> GetOwnerByIdAsync(Guid ownerId, CancellationToken cancellationToken = default);
}