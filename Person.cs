using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMI
{
    public class Person
    {
        public double Height { get; set; }
        public double Weight { get; set; }
        public double CalBMI()
        {
            return Weight / (Height * Height);
        }
    }
    
}