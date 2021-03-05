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
    public class ServiceCreneau : AService<Creneau>, IServiceCreneau
    {
        public ServiceCreneau(IRepositoryCreneau repositoryCreneau, IOptions<AppSettingsModel> settings) : base(repositoryCreneau, settings)
        {
            
        }
        public Task<bool> CreateCreneau(List<DateTime> dates, int idCommande)
        {
            return ((IRepositoryCreneau)Repository).CreateCreneau(dates, idCommande);
        }

        public Task<IEnumerable<Creneau>> GetListCreneauByIdCommande(int idCommande)
        {
            return ((IRepositoryCreneau)Repository).GetListCreneauByIdCommande(idCommande);
        }
    }
}
