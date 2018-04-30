using System.Linq;
using System.Reflection;
using FormsGenerator.Triggers;
using Xamarin.Forms;

namespace FormsGenerator.Strategy
{
    public class IntEntryStrategy : IViewStrategy
    {
        public View GetView(PropertyInfo property = null)
        {
            var entry = new Entry();
            var trigger = new EventTrigger();
            trigger.Event = "TextChanged";
            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            var maxValue = (FormMaxValue) property.GetCustomAttributes().FirstOrDefault(a => a.GetType() == typeof(FormMaxValue));
            if (maxValue != null)
            {
                trigger.Actions.Add(new IntTriggerAction(maxValue.MaxValue));
                entry.Placeholder = " max. " + maxValue.MaxValue;
            }
            else
            {
                trigger.Actions.Add(new IntTriggerAction());
            }
            entry.Triggers.Add(trigger);
            entry.Keyboard = Keyboard.Numeric;
            entry.HorizontalTextAlignment = TextAlignment.End;
            grid.Children.Add(entry, 1, 0);
            return grid;
        }
    }
}
