﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Metallic : Material
    {
        public int Blur { get; set; }
        public Metallic() : base(MaterialEnum.Metallic) { }
    }
}
