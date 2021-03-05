using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TP_DAL.Contrats;
using TP_DAL.Entities;

namespace TP_DAL.Services.Interfaces
{
    public interface IServiceCreneau : IService<Creneau>
    {
        Task<bool> CreateCreneau(List<DateTime> dates, int idCommande);
        Task<IEnumerable<Creneau>> GetListCreneauByIdCommande(int idCommande);
    }
}
