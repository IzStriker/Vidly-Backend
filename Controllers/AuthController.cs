using Backend.Models;
using Backend.Controllers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Transactions;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{

    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;

    public AuthController(
        UserManager<ApplicationUser> userManager,
        IConfiguration configuration
    )
    {
        _userManager = userManager;
        _configuration = configuration;
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

        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            // Create user
            var newUser = new ApplicationUser()
            {
                FirstName = body.FirstName!,
                LastName = body.LastName!,
                UserName = body.Email,
                Email = body.Email,
                SecurityStamp = Guid.NewGuid().ToString()
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

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> Login([FromBody] LoginModel body)
    {
        var user = await _userManager.FindByEmailAsync(body.Email);

        Console.WriteLine(user);

        if (user != null && await _userManager.CheckPasswordAsync(user, body.Password))
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            userRoles.ToList().ForEach((role) => authClaims.Add(new Claim(ClaimTypes.Role, role)));

            var token = GetToken(authClaims);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo,
                // TODO: use DTO to remove sensitive fields from user
                user = new
                {
                    user.Id,
                    user.Email,
                    user.FirstName,
                    user.LastName,
                }
            });

        }

        return Unauthorized();
    }

    private JwtSecurityToken GetToken(List<Claim> authClaims)
    {
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddDays(1),
            claims: authClaims,
            signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
        );

        return token;
    }
}