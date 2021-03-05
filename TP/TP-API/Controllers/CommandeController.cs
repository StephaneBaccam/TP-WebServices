using Microsoft.AspNetCore.Authorization;
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
    public class CommandeController : AController<Commande>
    {
        public CommandeController(IServiceCommande serviceCommande, IServiceUtilisateur serviceUtilisateur, IServiceStock serviceStock, IServiceCreneau serviceCreneau) : base(serviceCommande)
        {
            _serviceCommande = serviceCommande;
            _serviceUtilisateur = serviceUtilisateur;
            _serviceStock = serviceStock;
            _serviceCreneau = serviceCreneau;
        }

        [Authorize]
        //Commande d'un ou plusieurs produits
        [HttpPost("stock")]
        public async Task<IActionResult> CommandeArticle([FromBody] Commande commande)
        {
            var emailUtilisateur = User.Identities.First().Name;
            var utilisateur = await _serviceUtilisateur.GetUserByMail(emailUtilisateur);

            commande.utilisateur_id = utilisateur.Id;

            var stock = await _serviceStock.GetByIdAsync(commande.stock_id);

            if(stock.Quantite < commande.Quantite)
            {
                return BadRequest("Erreur : La quantité du produit dans la commande est supérieure à la quantité en stock");
            }
            else
            {
                await _serviceCommande.InsertAsync(commande);

                var commandes = _serviceCommande.GetAllAsync();
                var lastIdCommande = commandes.Result.OrderByDescending(lc => lc.Id).Select(lc => lc.Id).First();
                List<DateTime> dates = new List<DateTime>();

                DateTime dateReserv = DateTime.Now.AddDays(2);

                TimeSpan timeReserv1 = new TimeSpan(14, 0, 0);
                TimeSpan timeReserv2 = new TimeSpan(15, 0, 0);
                TimeSpan timeReserv3 = new TimeSpan(16, 0, 0);

                DateTime dateReserv1 = dateReserv.Date + timeReserv1;
                dates.Add(dateReserv1);

                DateTime dateReserv2 = dateReserv.Date + timeReserv2;
                dates.Add(dateReserv2);

                DateTime dateReserv3 = dateReserv.Date + timeReserv3;
                dates.Add(dateReserv3);

                await _serviceCreneau.CreateCreneau(dates, lastIdCommande);

                return Ok("Commande effectué, vous pouvez maintenant consulter la liste des crénaux disponible à la réservation");
            }
        }
    }
}
