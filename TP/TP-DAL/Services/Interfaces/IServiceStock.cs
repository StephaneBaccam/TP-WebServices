using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TP_DAL.Contrats;
using TP_DAL.Entities;

namespace TP_DAL.Services.Interfaces
{
    public interface IServiceStock : IService<Stock>
    {
        Task<IEnumerable<int>> GetIdArticlesFromMagasin(int id);
        Task<IEnumerable<Stock>> GetStockFromArticle(int id);
    }
}
