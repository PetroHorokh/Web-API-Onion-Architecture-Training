using Core.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(IAccountService invoiceService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAccounts(CancellationToken cancellationToken)
    {
        var accounts = await invoiceService.GetAllAccountsAsync(cancellationToken);

        return Ok(accounts);
    }
}