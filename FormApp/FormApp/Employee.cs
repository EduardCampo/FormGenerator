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
        public Gender Gender { get; set; }
        public DateTime Start { get; set; }
    }

    public enum Gender
    {
        Male = 0,
        Female = 1
    }
}
