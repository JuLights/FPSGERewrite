using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSGERewrite.Entities.DbSet
{
    public class Mouse
    {
        public Guid MouseId { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string AdditionalKeys { get; set; }
        public string SensorType { get; set; }
        public bool RGB { get; set; }

        //navigation properties
        public virtual Product Product { get; set; }
    }
}
