using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
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
    [EnableCors("Policy")]
    [Route("api/[controller]")]
    [ApiController]
    public abstract class AController<TModel> : ControllerBase, IController<TModel> where TModel : IEntity
    {
        private IService<TModel> _service;
        protected IServiceStock _serviceStock;
        protected IServiceArticle _serviceArticle;
        protected IServiceUtilisateur _serviceUtilisateur;
        protected IServiceCommande _serviceCommande;
        protected IServiceMessage _serviceMessage;
        protected IServiceCreneau _serviceCreneau;
        protected IServiceReservation _serviceReservation;
        protected IEmailSender _emailSender;

        public AController(IService<TModel> service)
        {
            _service = service;
        }

        [HttpGet("getall")]
        public async Task<IEnumerable<TModel>> GetAllAsync()  //CRUD - Read
        {
            var res = await _service.GetAllAsync();  //Passage couche AService 
            return res;
        }

        [HttpGet("get/{id}")]
        public async Task<TModel> GetByIdAsync([FromRoute] int id)  //CRUD - Read
        {
            return await _service.GetByIdAsync(id);  //Passage couche AService 
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("insert")]
        public async Task<IActionResult> InsertAsync([FromBody] TModel model)  //CRUD - Create
        {
            try
            {
                await _service.InsertAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erreur dans l'insertion : " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] TModel model)  //CRUD - Update
        {
            try
            {
                await _service.UpdateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erreur dans la mise à jour de la table : " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync([FromBody] int id)   //CRUD - Delete
        {
            await _service.DeleteAsync(id);   //Passage couche AService avec {id} pour cibler la bonne ligne
            return Ok();
        }
    }
}
