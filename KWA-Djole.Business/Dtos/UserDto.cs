using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWA_Djole.Business.Dtos
{
    public class UserDto : BaseDto
    {
        public CustomerCartDto Cart { get; set; }
    }
}