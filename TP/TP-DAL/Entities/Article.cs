using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_DAL.Contrats;

namespace TP_DAL.entities
{
    public class Article : AEntity
    {
        public string Nom { get; set; }
    }
}
