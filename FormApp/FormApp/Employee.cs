using System;
using FormsGenerator;

namespace FormApp
{
    public class Employee
    {
        [FormMaxLength(10)]
        public string Name { get; set; }
        public int Salary { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public Gender Gender { get; set; }
        public Status Status { get; set; }
        public DateTime Start { get; set; }
        [FormPassword]
        public string PasswordString { get; set; }
        [FormOptional]
        public string OptionalString { get; set; }
        [FormIgnore]
        public int IgnoredInt { get; set; }
        [FormMaxValue(500)]
        public int IntMax { get; set; }
        [FormIntSlider(0,100,50)]
        public int SliderNumber { get; set; }
    }

    public enum Gender
    {
        Male = 0,
        Female = 1,
        ApacheAttackHelicopter = 2,
        
    }

    public enum Status
    {
        Single = 0,
        Married = 1,
        Divorced = 2,
        Other = 3
    }
}
