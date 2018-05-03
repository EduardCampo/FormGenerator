using System;

namespace FormsGenerator
{
    /// <summary>
    /// [int, string] Entries can be sent empty
    /// </summary>
    public class FormOptional : Attribute
    {
    }
    /// <summary>
    /// [any] Property will be ignored by FormsGenerator
    /// </summary>
    public class FormIgnore : Attribute  
    {
    }
    /// <summary>
    /// [string] Entry will have the property IsPassword = true
    /// </summary>
    public class FormPassword : Attribute
    {
    }
    /// <summary>
    /// [string] Entry will have a maximum length of MaxLength
    /// </summary>
    public class FormMaxLength : Attribute
    {
        public int MaxLength;
        public FormMaxLength(int n)
        {
            MaxLength = n;
        }
    }
    /// <summary>
    /// [int] Entry won't allow numbers greater than MaxValue
    /// </summary>
    public class FormMaxValue : Attribute
    {
        public int MaxValue;
        public FormMaxValue(int maxValue)
        {
            MaxValue = maxValue;
        }
    }
    /// <summary>
    /// [int] Slider shows up instead of an entry. Requires MinValue and MaxValue.
    /// Default value is optional.
    /// </summary>
    public class FormIntSlider : Attribute
    {
        public int MaxValue;
        public int MinValue;
        public int DefaultValue;
        public FormIntSlider(int minValue, int maxValue, int defaultValue = 0)
        {
            MaxValue = maxValue;
            MinValue = minValue;
            if (defaultValue != 0)
            {
                DefaultValue = defaultValue;
            }
            else
            {
                DefaultValue = minValue;
            }
            
        }
    }

}
