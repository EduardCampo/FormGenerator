using System;
using System.Collections.Generic;
using System.Text;

namespace FormApp
{
    public class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public bool IsAdmin { get; set; }
        //public Sex Sex { get; set; }
    }

    public enum Sex
    {
        Male = 0,
        Female = 1
    }
}
