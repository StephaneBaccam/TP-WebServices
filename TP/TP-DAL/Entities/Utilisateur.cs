using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_DAL.Contrats;

namespace TP_DAL.Entities
{
    public class Utilisateur : AEntity
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
    }
}
