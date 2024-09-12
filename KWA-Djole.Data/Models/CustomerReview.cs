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
        public OrderItem Item { get; set; }
        public int ItemId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}