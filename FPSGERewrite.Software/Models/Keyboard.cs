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

        //try
        //public ImageSource Src { get;set; }
        [AllowNull]
        public byte[] ImageData { get; set; }
        public string Base64Image 
        { 
            get => Convert.ToBase64String(ImageData); 
            set => ImageData = Convert.FromBase64String(value);
        }

        //navigation properties
        public virtual Product Product { get; set; }
    }
}
