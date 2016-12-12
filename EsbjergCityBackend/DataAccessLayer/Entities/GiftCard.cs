using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class GiftCard : AbstractId
    {        
        public string CardNumber { get; set; }        
        public double Amount { get; set; }
    }
}
