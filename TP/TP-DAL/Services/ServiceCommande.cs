using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using TP_DAL.Contrats;
using TP_DAL.Entities;
using TP_DAL.Models;
using TP_DAL.Services.Interfaces;

namespace TP_DAL.Services
{
    public class ServiceCommande : AService<Commande>, IServiceCommande
    {
        public ServiceCommande(IRepositoryCommande repositoryCommande, IOptions<AppSettingsModel> settings) : base(repositoryCommande, settings)
        {

        }
    }
}
