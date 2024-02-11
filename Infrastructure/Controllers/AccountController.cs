using Core.Models;
using Core.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(IAccountService invoiceService) : ControllerBase
{
    [HttpGet("GetAllAccounts")]
    public async Task<IActionResult> GetAllAccounts(
        CancellationToken cancellationToken)
    {
        var accounts = await invoiceService.GetAllAccountsAsync(cancellationToken);

        if(accounts.IsNullOrEmpty())
        {
            return NoContent();
        }
        else
        {
            return Ok(accounts);
        }
    }

    [HttpGet("GetAccountsByAccountType/{accountType:required}")]
    public async Task<IActionResult> GetAccountsByAccountType(
        string accountType, 
        CancellationToken cancellationToken)
    {
        var accounts = await invoiceService.GetAccountsByAccountTypeAsync(accountType ,cancellationToken);

        if (accounts.IsNullOrEmpty())
        {
            return NoContent();
        }
        else
        {
            return Ok(accounts);
        }
    }

    [HttpGet("GetAccountsByOwner/{ownerId:guid}")]
    public async Task<IActionResult> GetAccountsByOwner(
        Guid ownerId, 
        CancellationToken cancellationToken)
    {
        var accounts = await invoiceService.GetAccountsByOwnerIdAsync(ownerId, cancellationToken);

        if (accounts.IsNullOrEmpty())
        {
            return NoContent();
        }
        else
        {
            return Ok(accounts);
        }
    }

    [HttpGet("GetAccountById/{accountId:guid}")]
    public async Task<IActionResult> GetAccountById(
        Guid accountId, 
        CancellationToken cancellationToken)
    {
        var account = await invoiceService.GetAccountByIdAsync(accountId, cancellationToken);

        if (account == null)
        {
            return NoContent();
        }
        else
        {
            return Ok(account);
        }
    }

    [HttpPost("CreateAccount")]
    public async Task<IActionResult> CreateAccount(
        [FromBody] Account account, 
        CancellationToken cancellationToken)
    {
        await invoiceService.CreateAccountAsync(account, cancellationToken);

        return NoContent();
    }

    [HttpDelete("DeleteAccount/{accountId:guid}")]
    public async Task<IActionResult> DeleteAccount(
        Guid accountId, 
        CancellationToken cancellationToken)
    {
        var account = await invoiceService.DeleteAccountAsync(accountId, cancellationToken);

        if(account is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(account);
        }
    }

    [HttpPut("UpdateAccount/{accountId:guid}")]
    public async Task<IActionResult> UpdateAccount(
        Guid accountId, 
        [FromBody] Account accountUpdate, 
        CancellationToken cancellationToken)
    {
        var account = await invoiceService.UpdateAccountAsync(accountId, accountUpdate, cancellationToken);

        if (account is null)
        {
            return NotFound();
        }

        return Ok(account);
    }
}