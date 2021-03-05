using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TP_DAL.Entities;

namespace TP_DAL.Contrats
{
    public interface IRepositoryCreneau : IRepository<Creneau>
    {
        Task<bool> CreateCreneau(List<DateTime> dates, int idCommande);
        Task<IEnumerable<Creneau>> GetListCreneauByIdCommande(int idCommande);
    }
}
