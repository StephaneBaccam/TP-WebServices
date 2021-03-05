using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TP_DAL.Entities;

namespace TP_DAL.Contrats
{
    public interface IRepositoryUtilisateur : IRepository<Utilisateur>
    {
        Task<Utilisateur> GetUserByMail(string email);
        Task<string> GetUserPassword(string emailUtilisateur);
    }
}
