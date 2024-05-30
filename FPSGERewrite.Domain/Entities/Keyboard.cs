using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSGERewrite.Domain.Entities
{
    public class Keyboard
    {
        public Guid KeyboardId { get; set; }
        public string CableLength { get; set; }
        public string SwitchType { get; set; } //mechanical, membrane, .. etc.
        public string Brand { get; set; }
        public string Color { get; set; }
        public string RGB { get; set; }

        //navigation properties
        public virtual Product Product { get; set; }
    }
}
