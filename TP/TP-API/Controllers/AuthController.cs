using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TP_API.Helper;
using TP_DAL.Entities;
using TP_DAL.Services.Interfaces;

namespace TP_API.Controllers
{
    [Authorize]
    [ResponseCache(CacheProfileName = "Default")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppSettings settings;
        private readonly IServiceUtilisateur _serviceUtilisateur;

        public AuthController(IOptions<AppSettings> settings, IServiceUtilisateur serviceUtilisateur)
        {
            this.settings = settings.Value;
            _serviceUtilisateur = serviceUtilisateur;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] Utilisateur utilisateur)
        {
            var utilisateurDb = await _serviceUtilisateur.GetUserByMail(utilisateur.Email);
            
            if(utilisateur.Password != utilisateurDb.Password)
            {
                return BadRequest("Erreur : Mauvais login ou mot de passe");
            }

            //Création d'un token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, utilisateurDb.Email),      //Stock email de l'utilisateur dans ClaimIdentity
                    new Claim(ClaimTypes.Role, utilisateurDb.Role)
                }),
                Expires = DateTime.Now.AddMinutes(settings.TokenLifeTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(tokenString);     //Envoi du token
        }
    }
}
