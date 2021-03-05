using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_DAL.Contrats;

namespace TP_DAL.Entities
{
    public class Creneau : AEntity
    {
        public DateTime Date { get; set; }
        public int commande_id { get; set; }
    }
}
