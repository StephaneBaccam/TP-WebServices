using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_DAL.Contrats;

namespace TP_DAL.Entities
{
    public class Commande : AEntity
    {
        public int utilisateur_id { get; set; }
        public int stock_id { get; set; }
        public int Quantite { get; set; }
    }
}
