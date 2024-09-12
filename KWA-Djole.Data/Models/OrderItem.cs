using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWA_Djole.Data.Models
{
    public class OrderItem : BaseModel
    {
        public Order? Order { get; set; }
        public int OrderId { get; set; }
        public ShoppingItem? ShoppingItem { get; set; }
        public int ShoppingItemId { get; set; }
    }
}