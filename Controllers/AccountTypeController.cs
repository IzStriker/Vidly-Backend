using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountTypeController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AccountTypeController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var types = _context.AccountTypes!.ToList();

        if (types.Count < 1)
        {
            return NoContent();
        }

        return Ok(types);
    }
}
