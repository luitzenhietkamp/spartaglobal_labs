﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_42_testme
{
    public class TestMe
    {
        public double BIDMAS01(int x, int y, int z)
        {
            // goal : x + y / z observing BIDMAS rules

            return x + (double)y / z; // -1 means 'fail'
        }
    }
}
