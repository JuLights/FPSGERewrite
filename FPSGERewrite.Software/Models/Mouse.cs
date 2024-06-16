using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSGERewrite.Software.Models
{
    public class Mouse
    {
        public Guid MouseId { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string AdditionalKeys { get; set; }
        public string SensorType { get; set; }
        public bool RGB { get; set; }
        [AllowNull]
        public byte[] ImageData { get; set; }

        //navigation properties
        public virtual Product Product { get; set; }
    }
}
