﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos
{
    public class ProductCreatedMessageDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ?CategoryId { get; set; }
    }
}
