﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWA_Djole.Data.Models
{
    public class ShoppingItemGenre : BaseModel
    {
        public string Name { get; set; }
        public List<ShoppingItem> ShoppingItems { get; set; }
    }
}