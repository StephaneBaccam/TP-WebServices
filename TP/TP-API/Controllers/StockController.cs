using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_DAL.entities;
using TP_DAL.Entities;
using TP_DAL.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : AController<Stock>
    {
        public StockController(IServiceStock serviceStock, IServiceArticle serviceArticle) : base(serviceStock)
        {
            _serviceStock = serviceStock;
            _serviceArticle = serviceArticle;
        }

        //Recup des articles d'un magasin
        [HttpGet("magasin/{id}/articles")]
        public async Task<List<Article>> GetIdArticlesFromMagasin([FromRoute] int id)
        {
            List<Article> Articles = new List<Article>();
            var idArticles = await _serviceStock.GetIdArticlesFromMagasin(id);

            if(idArticles.Any())
            {
                foreach(var idArticle in idArticles)
                {
                    var article = await _serviceArticle.GetByIdAsync(idArticle);
                    Articles.Add(article);
                }
            }
            return Articles;
        }

        //Recup de la quantite d'un article
        [HttpGet("article/{id}")]
        public async Task<Stock> GetStockFromArticle([FromRoute] int id)
        {
            var stock = await _serviceStock.GetStockFromArticle(id);

            return stock.First();
        }
    }
}   
