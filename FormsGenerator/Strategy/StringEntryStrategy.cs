﻿using System.Linq;
using System.Reflection;
using FormsGenerator.Triggers;
using Xamarin.Forms;

namespace FormsGenerator.Strategy
{
    public class StringEntryStrategy : ViewStrategy
    {
        public StringEntryStrategy(PropertyInfo property) : base(property)
        {
        }
        public override View GetView()
        {
            var entry = new Entry();
            var attributeList = Property.GetCustomAttributes();
            var attribute = attributeList.FirstOrDefault(a => a.GetType() == typeof(FormPassword));
            if (attribute != null)
            {
                entry.IsPassword = true;
            }
            var attribute2 = (FormMaxLength) attributeList.FirstOrDefault(a => a.GetType() == typeof(FormMaxLength));
            if (attribute2 != null)
            {
                var trigger = new EventTrigger();
                trigger.Event = "TextChanged";
                trigger.Actions.Add(new StringTriggerAction(attribute2.MaxLength));
                entry.Triggers.Add(trigger);
            }
            return entry;
        }
    }
}
