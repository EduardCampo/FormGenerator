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
            var entry = new Entry();
            var trigger = new EventTrigger();
            trigger.Event = "TextChanged";
            trigger.Actions.Add(new IntTriggerAction());
            entry.Triggers.Add(trigger);
            entry.Keyboard = Keyboard.Numeric;
            return entry;
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
                picker.ItemsSource = System.Enum.GetValues(enumType);
                picker.SelectedIndex = 0;
            }
            return picker;
        }
        private View GetDatePicker()
        {
            return new DatePicker();
        }
    }
}
