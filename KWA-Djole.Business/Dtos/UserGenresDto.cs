using KWA_Djole.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWA_Djole.Business.Dtos
{
    public class UserGenresDto
    {
        public string UserId { get; set; }
        public ShoppingItemGenreDto Genre { get; set; }
        public int GenreId { get; set; }
    }
}