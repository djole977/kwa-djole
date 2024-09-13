using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWA_Djole.Business.Dtos
{
    public class FilterDto
    {
        public string? Name { get; set; }
        public List<int>? GenresId { get; set; }
        public int? NumOfPages { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
    }
}