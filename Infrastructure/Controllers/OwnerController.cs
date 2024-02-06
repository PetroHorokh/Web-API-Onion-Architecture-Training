using Core.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OwnerController(IOwnerService invoiceService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllOwners(CancellationToken cancellationToken)
    {
        var owners = await invoiceService.GetAllOwnersAsync(cancellationToken);

        return Ok(owners);
    }
}