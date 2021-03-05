using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TP_DAL.Contrats;
using TP_DAL.Entities;
using TP_DAL.Models;
using TP_DAL.Services.Interfaces;

namespace TP_DAL.Services
{
    public class ServiceStock : AService<Stock>, IServiceStock
    {
        public ServiceStock(IRepositoryStock repositoryStock, IOptions<AppSettingsModel> settings) : base(repositoryStock, settings)
        {

        }

        public Task<IEnumerable<int>> GetIdArticlesFromMagasin(int id)
        {
            return ((IRepositoryStock)Repository).GetIdArticlesFromMagasin(id);
        }

        public Task<IEnumerable<Stock>> GetStockFromArticle(int id)
        {
            return ((IRepositoryStock)Repository).GetStockFromArticle(id);
        }
    }
}
