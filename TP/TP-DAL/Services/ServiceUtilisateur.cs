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
    public class ServiceUtilisateur : AService<Utilisateur>, IServiceUtilisateur
    {
        public ServiceUtilisateur(IRepositoryUtilisateur repositoryUtilisateur, IOptions<AppSettingsModel> settings) : base(repositoryUtilisateur, settings)
        {
            
        }
        public Task<Utilisateur> GetUserByMail(string email)
        {
            return ((IRepositoryUtilisateur)Repository).GetUserByMail(email);
        }

        public Task<string> GetUserPassword(string emailUtilisateur)
        {
            return ((IRepositoryUtilisateur)Repository).GetUserPassword(emailUtilisateur);
        }
    }
}
