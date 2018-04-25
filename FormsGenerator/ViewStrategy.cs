using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace FormsGenerator
{
    public class ViewStrategy : Dictionary<Type, View>
    {
        public PropertyInfo Property { get; set; }
        public ViewStrategy(PropertyInfo property)
        {
            Property = property;
            Add(typeof(string), GetStringEntry());
            Add(typeof(int), GetIntEntry());
            Add(typeof(bool), GetSwitch());
            Add(typeof(Enum), GetPicker());
            Add(typeof(DateTime), GetDatePicker());
        }
        private View GetStringEntry()
        {
            return new Entry();
        }
        private View GetIntEntry()
        {
            return new Entry();
        }
        private View GetSwitch()
        {
            return new Switch();
        }
        private View GetPicker()
        {
            var picker = new Picker();
            if (Property.PropertyType.BaseType == typeof(Enum))
            {
                var enumType = Property.PropertyType;
                //var enumValues = System.Enum.GetValues(enumType);
                picker.ItemsSource = System.Enum.GetValues(enumType);
            }
            return picker;
        }
        private View GetDatePicker()
        {
            return new DatePicker();
        }
    }
}
