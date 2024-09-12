using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWA_Djole.Data.Models
{
    public class CustomerReview : BaseModel
    {
        public string? UserId { get; set; }
        public ShoppingItem ShoppingItem { get; set; }
        public int ShoppingItemId { get; set; }
    }
}