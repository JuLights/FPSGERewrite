using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSGERewrite.Domain.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; } = Guid.NewGuid();
        public string ProductName { get; set; } = string.Empty;
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public decimal Price { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCondition { get; set; }

        //Navigation properties
        public Guid? MouseId { get; set; }
        public virtual Mouse Mouse { get; set; }
        public Guid? KeyboardId { get; set; }
        public virtual Keyboard Keyboard { get; set; }
    }

}
