using Backend.Models;
using Backend.Controllers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{

    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;

    public AuthController(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration
    )
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel body)
    {
        var userExists = await _userManager.FindByEmailAsync(body.Email);
        if (userExists != null)
        {
            return BadRequest(new Response { Status = "Error", Message = "User Already exists." });
        }

        var user = new ApplicationUser()
        {
            FirstName = body.FirstName!,
            LastName = body.LastName!,
            UserName = body.Email,
            Email = body.Email,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        var result = await _userManager.CreateAsync(user, body.Password);
        if (!result.Succeeded)
        {
            return BadRequest(new Response() { Status = "Error", Message = "User Creation failed, check details and try again." });
        }

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
                expiration = token.ValidTo
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