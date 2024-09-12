using KWA_Djole.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWA_Djole.Business.Dtos
{
    public class ShoppingItemDto : BaseDto
    {
        public string? Name { get; set; }
        public string? Genre { get; set; }
        public int NumOfPages { get; set; }
        public string? Issuer { get; set; }
        public DateTime IssueDate { get; set; }
        public float Price { get; set; }
        public List<CustomerReviewDto>? CustomerReviews { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsDetailsPage { get; set; } = false;
        public ShoppingItemGenreDto ShoppingItemGenre { get; set; }
        public int ShoppingItemGenreId { get; set; }
    }
}