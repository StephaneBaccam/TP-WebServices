using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_DAL.Contrats;
using TP_DAL.Entities;
using TP_DAL.Models;
using TP_DAL.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurController : AController<Utilisateur>
    {

        public UtilisateurController(IServiceUtilisateur serviceUtilisateur, IEmailSender emailSender) : base(serviceUtilisateur)
        {
            _serviceUtilisateur = serviceUtilisateur;
            _emailSender = emailSender;
        }

        [HttpPost("inscription")] 
        public async Task<IActionResult> InscriptionUtilisateur([FromBody] Utilisateur utilisateur)
        {
            await _serviceUtilisateur.InsertAsync(utilisateur);
            return Ok("Utilisateur inscrit");
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("send-mail")]
        public IActionResult SendMail([FromBody] Utilisateur utilisateur)
        {
            var message = new MailMessage(new string[] { utilisateur.Email }, "Validation de votre commande", "Bonjour, votre commande a été validée");
            _emailSender.SendEmail(message);

            return Ok("Mail envoyé");
        }
    }
}
