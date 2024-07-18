using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Pgiornaliero.Models;
using Pgiornaliero.ViewModels;

namespace Pgiornaliero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return Unauthorized();  // Utente non trovato
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                // Genera il token JWT o altra logica di autenticazione
                var token = await GenerateJwtToken(user);
                return Ok(new { Token = token });
            }

            return Unauthorized();  // Autenticazione fallita
        }

        private async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            // Implementa la logica per generare il token JWT
            // Esempio: var token = await _jwtService.GenerateTokenAsync(user);
            return "jwt_token_generato";  // Sostituire con la logica reale
        }
    }
}