using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Microsoft.AspNetCore.Identity;
using Backend.Controllers.Models;
using System.Transactions;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;

    private readonly ApplicationDbContext _context;

    public CustomerController(
        UserManager<ApplicationUser> userManager,
        IConfiguration configuration,
        ApplicationDbContext context
    )
    {
        _userManager = userManager;
        _configuration = configuration;
        _context = context;
    }

    /// <summary>
    /// Allow customer to register accounts.
    /// </summary>
    /// <param name="body"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel body)
    {
        var userExists = await _userManager.FindByEmailAsync(body.Email);
        if (userExists != null)
        {
            return BadRequest(new Response { Status = "Error", Message = "User Already exists." });
        }

        var accountType = _context.AccountTypes!.FirstOrDefault(type => type.Id == body.AccountTypeId);
        if (accountType == null)
        {
            return BadRequest(new Response { Status = "Error", Message = "Invalid Account Type doesn't exist." });
        }

        // check if user is old enough for the given account type
        if (body.DateOfBirth.AddYears(accountType.RequiredAge) > DateTime.Now)
        {
            return BadRequest(new Response
            {
                Status = "Error",
                Message = $"User must be {accountType.RequiredAge} to use this account type."
            });
        }


        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {

            // Create user
            var newUser = new ApplicationUser()
            {
                FirstName = body.FirstName!,
                LastName = body.LastName!,
                UserName = body.Email,
                Email = body.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                CustomerDetails = new CustomerDetails()
                {
                    DateOfBirth = DateOnly.FromDateTime(body.DateOfBirth),
                    AccountType = accountType
                }
            };

            var result = await _userManager.CreateAsync(newUser, body.Password);
            if (!result.Succeeded)
            {
                return BadRequest(new { Status = "Error", Errors = result.Errors });
            }

            // Assign user customer role 
            var user = await _userManager.FindByEmailAsync(body.Email);

            result = await _userManager.AddToRoleAsync(user, ApplicationUserRoles.CUSTOMER);

            if (!result.Succeeded)
            {
                // Remove user if error assigning role.
                scope.Dispose();
                return StatusCode(500, new { Status = "Error", Errors = result.Errors });
            }

            scope.Complete();
        }

        // TODO: link to get user
        return Created("", new Response() { Status = "Success", Message = "User Created" });
    }
}
