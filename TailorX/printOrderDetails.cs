using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TailorX
{
    public class printOrderDetails
    {
        public string customerName { get; set; }
        public string product_type { get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; }       
        public decimal paid { get; set; }
        public decimal due { get; set; }
        public decimal total_price {

            get
            {
                return price * quantity ;
            }
        }
    }
}
