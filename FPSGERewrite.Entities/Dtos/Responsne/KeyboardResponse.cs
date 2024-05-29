using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSGERewrite.Entities.Dtos.Responsne
{
    public class KeyboardResponse
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public decimal Price { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCondition { get; set; }

        public Guid KeyboardId { get; set; }
        public string CableLength { get; set; }
        public string SwitchType { get; set; } //mechanical, membrane, .. etc.
        public string Brand { get; set; }
        public string Color { get; set; }
        public string RGB { get; set; }
    }
}
