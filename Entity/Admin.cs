﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
