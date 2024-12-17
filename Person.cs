using System;

namespace BMI
{
    public class Person
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        public double CalBMI()
        {
            return Weight / (Height * Height);
        }
    }
}