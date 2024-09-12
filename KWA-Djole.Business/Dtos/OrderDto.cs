using KWA_Djole.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWA_Djole.Business.Dtos
{
    public class OrderDto : BaseDto
    {
        public string UserId { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }
}