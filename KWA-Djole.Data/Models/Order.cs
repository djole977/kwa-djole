using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWA_Djole.Data.Models
{
    public class Order : BaseModel
    {
        public string UserId { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}