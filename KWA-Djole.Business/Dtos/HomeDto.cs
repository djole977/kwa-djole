using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWA_Djole.Business.Dtos
{
    public class HomeDto
    {
        public List<ShoppingItemDto>? ShoppingItems { get; set; }
        public int TotalItems { get; set; }
        public List<ShoppingItemGenreDto>? Genres { get; set; }
    }
}