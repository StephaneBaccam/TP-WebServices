using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TP_DAL.Entities;

namespace TP_DAL.Contrats
{
    public interface IRepositoryStock : IRepository<Stock>
    {
        Task<IEnumerable<int>> GetIdArticlesFromMagasin(int id);
        Task<IEnumerable<Stock>> GetStockFromArticle(int id);
    }
}
