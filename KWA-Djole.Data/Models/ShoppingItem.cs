using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWA_Djole.Data.Models
{
    public class ShoppingItem : BaseModel
    {
        public string? Name { get; set; }
        public string? Genre { get; set; }
        public int NumOfPages { get; set; }
        public string? Issuer { get; set; }
        public DateTime IssueDate { get; set; }
        public float Price { get; set; }
        public List<CustomerReview>? CustomerReviews { get; set; }
        public string? ImageUrl { get; set; }
        public ShoppingItemGenre ShoppingItemGenre { get; set; }
        public int ShoppingItemGenreId { get; set; }
    }
}