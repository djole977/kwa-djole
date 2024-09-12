using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWA_Djole.Data.Models
{
    public class UserGenres : BaseModel
    {
        public string UserId { get; set; }
        public ShoppingItemGenre Genre { get; set; }
        public int GenreId { get; set; }
    }
}