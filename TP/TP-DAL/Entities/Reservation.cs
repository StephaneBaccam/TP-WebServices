using System;
using System.Collections.Generic;
using System.Text;
using TP_DAL.Contrats;

namespace TP_DAL.Entities
{
    public class Reservation : AEntity
    {
        public int creneau_id { get; set; }
        public int utilisateur_id { get; set; }
    }
}
