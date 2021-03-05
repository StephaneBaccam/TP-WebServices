using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_DAL.Contrats;

namespace TP_DAL.Entities
{
    public class Message : AEntity
    {
        public int MessageToId { get; set; }
        public string TextMessage { get; set; }
    }
}
