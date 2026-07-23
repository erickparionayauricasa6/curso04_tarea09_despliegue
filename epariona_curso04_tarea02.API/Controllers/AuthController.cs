using epariona_curso04_tarea02.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace epariona_curso04_tarea02.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    // La clave debe coincidir con la de Program.cs
    private readonly string _secretKey = "MiSuperClaveSecretaParaElTokenJwt123456"; 

    public AuthController(AppDbContext context)
    {
        _context = context;
        SeedUser(context);
    }

    private void SeedUser(AppDbContext context)
    {
        if (!context.Usuarios.Any())
        {
            context.Usuarios.Add(new Domain.Entities.Usuario 
            { 
                NombreUsuario = "admin", 
                Email = "admin@admin.com", 
                Password = "123" 
            });
            context.SaveChanges();
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Email == request.Email && u.Password == request.Password);

        if (user == null)
            return Unauthorized("Credenciales inválidas");

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] 
            {
                new Claim(ClaimTypes.Name, user.NombreUsuario),
                new Claim(ClaimTypes.Email, user.Email)
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return Ok(new { Token = tokenHandler.WriteToken(token) });
    }
}

public class LoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
