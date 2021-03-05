using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_DAL.Contrats;

namespace TP_DAL.Entities
{
    public class Stock : AEntity
    {
        public int Quantite { get; set; }
        public int magasin_id { get; set; }
        public int article_id { get; set; }
    }
}
