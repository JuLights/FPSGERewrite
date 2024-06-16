using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSGERewrite.Software.Models
{
    public class Keyboard
    {
        public Guid KeyboardId { get; set; }
        public string CableLength { get; set; }
        public string SwitchType { get; set; } //mechanical, membrane, .. etc.
        public string Brand { get; set; }
        public string Color { get; set; }
        public string RGB { get; set; }
        [AllowNull]
        public byte[] ImageData { get; set; }

        //navigation properties
        public virtual Product Product { get; set; }
    }
}
