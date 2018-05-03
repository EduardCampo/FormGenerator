using System;
using System.Collections.Generic;
using System.Reflection;
using FormsGenerator.Utilities;
using Xamarin.Forms;

namespace FormsGenerator.Strategy
{
    public class EnumPickerStrategy : IViewStrategy
    {
        public View GetView(PropertyInfo property)
        {
            var picker = new Picker();
            var enumType = property.PropertyType;
            var enumList = new List<string>();
            foreach (var item in Enum.GetValues(enumType))
            {
                enumList.Add(item.ToString().SplitCamelCase());
            }
            picker.ItemsSource = enumList;
            picker.SelectedIndex = 0;
            return picker;
        }
    }
}
