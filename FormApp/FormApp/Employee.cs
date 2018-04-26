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
        public bool IsActive { get; set; }
        public Gender Gender { get; set; }
        public Status Status { get; set; }
        public DateTime Start { get; set; }
    }

    public enum Gender
    {
        Male = 0,
        Female = 1
    }

    public enum Status
    {
        Single = 0,
        Married = 1,
        Divorced = 2,
        Other = 3
    }
}
