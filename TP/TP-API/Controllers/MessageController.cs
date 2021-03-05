using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_DAL.Entities;
using TP_DAL.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : AController<Message>
    {
        public MessageController(IServiceMessage serviceMessage, IServiceUtilisateur serviceUtilisateur) : base(serviceMessage)
        {
            _serviceMessage = serviceMessage;
            _serviceUtilisateur = serviceUtilisateur;
        }

        [HttpPost("send-message")]
        public async Task<IActionResult> SendMessage([FromBody] Message message)
        {
            bool destinataireDb = false;
            var utilisateurs = _serviceUtilisateur.GetAllAsync();

            destinataireDb = utilisateurs.Result.Where(ut => ut.Id == message.MessageToId).Any();

            if (destinataireDb == false)
            {
                return BadRequest("Utilisateur introuvable");
            }

            await _serviceMessage.InsertAsync(message);
            return Ok("Message envoyé");
        }
    }
}
