using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSGERewrite.Application.Dtos.Response
{
    public class MouseResponse
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public decimal Price { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCondition { get; set; }

        public Guid MouseId { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string AdditionalKeys { get; set; }
        public string SensorType { get; set; }
        public bool RGB { get; set; }
    }
}
