using Core.Models;
using Core.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OwnerController(IOwnerService invoiceService) : ControllerBase
{
    [HttpGet("GetAllOwners")]
    public async Task<IActionResult> GetAllOwners(
        CancellationToken cancellationToken)
    {
        var owners = await invoiceService.GetAllOwnersAsync(cancellationToken);
         
        if (owners.IsNullOrEmpty())
        {
            return NoContent();
        }
        else
        {
            return Ok(owners);
        }
    }

    [HttpGet("GetOwnersByName/{name:required}")]
    public async Task<IActionResult> GetOwnersByName(
        string name, 
        CancellationToken cancellationToken)
    {
        var owners = await invoiceService.GetOwnersByNameAsync(name, cancellationToken);

        if (owners.IsNullOrEmpty())
        {
            return NoContent();
        }
        else
        {
            return Ok(owners);
        }
    }

    [HttpGet("GetOwnersByAddress/{address:required}")]
    public async Task<IActionResult> GetOwnersByAddress(
        string address, 
        CancellationToken cancellationToken)
    {
        var owners = await invoiceService.GetOwnersByAddressAsync(address, cancellationToken);

        if (owners.IsNullOrEmpty())
        {
            return NoContent();
        }
        else
        {
            return Ok(owners);
        }
    }

    [HttpGet("GetOwnersByDateOfBirth/{dateOfBirth:required}")]
    public async Task<IActionResult> GetOwnersByDateOfBirth(
        DateTime dateOfBirth, 
        CancellationToken cancellationToken)
    {
        var owners = await invoiceService.GetOwnersByDateOfBirthAsync(dateOfBirth, cancellationToken);

        if (owners.IsNullOrEmpty())
        {
            return NoContent();
        }
        else
        {
            return Ok(owners);
        }
    }

    [HttpGet("GetOwnerByAccountId/{accountId:guid}")]
    public async Task<IActionResult> GetOwnerByAccountId(
        Guid accountId, 
        CancellationToken cancellationToken)
    {
        var owner = await invoiceService.GetOwnerByAccountIdAsync(accountId, cancellationToken);

        if (owner == null)
        {
            return NoContent();
        }
        else
        {
            return Ok(owner);
        }
    }

    [HttpGet("GetOwnerById/{ownerId:guid}")]
    public async Task<IActionResult> GetOwnerById(
        Guid ownerId, 
        CancellationToken cancellationToken)
    {
        var owner = await invoiceService.GetOwnerByIdAsync(ownerId, cancellationToken);

        if (owner == null)
        {
            return NoContent();
        }
        else
        {
            return Ok(owner);
        }
    }

    [HttpPost("CreateOwner")]
    public async Task<IActionResult> CreateOwner(
        [FromBody] Owner owner,
        CancellationToken cancellationToken)
    {
        await invoiceService.CreateOwnerAsync(owner, cancellationToken);

        return NoContent();
    }

    [HttpDelete("DeleteOwner/{ownerId:guid}")]
    public async Task<IActionResult> DeleteOwner(
        Guid ownerId,
        CancellationToken cancellationToken)
    {
        var owner = await invoiceService.DeleteOwnerAsync(ownerId, cancellationToken);

        if (owner is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(owner);
        }
    }

    [HttpPut("UpdateOwner/{ownerId:guid}")]
    public async Task<IActionResult> UpdateOwner(
        Guid ownerId,
        [FromBody] Owner ownerUpdate,
        CancellationToken cancellationToken)
    {
        var owner = await invoiceService.UpdateOwnerAsync(ownerId, ownerUpdate, cancellationToken);

        if (owner is null)
        {
            return NotFound();
        }

        return Ok(owner);
    }
}