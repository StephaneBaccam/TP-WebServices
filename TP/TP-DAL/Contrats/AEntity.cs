using System;
using System.Collections.Generic;
using System.Text;

namespace TP_DAL.Contrats
{
    public abstract class AEntity : IEntity 
    {
        public int Id { get; set; }
    }
}
