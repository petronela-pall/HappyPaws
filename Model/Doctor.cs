﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace HappyPaws.Model
{
    public class Doctor
    {
        public int ID { get; set; }
        public string Name { get; set; }


        public string Description { get; set; }

        public byte[] Picture { get; set; }

    }
}
