using System.Linq;
using System.Reflection;
using FormsGenerator.Triggers;
using Xamarin.Forms;

namespace FormsGenerator.Strategy
{
    public class IntEntryStrategy : ViewStrategy
    {
        public IntEntryStrategy(PropertyInfo property) : base(property)
        {
        }
        public override View GetView()
        {
            var entry = new Entry();
            
            var trigger = new EventTrigger();
            trigger.Event = "TextChanged";
            var innerGrid = new Grid();
            innerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            innerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            var maxValue = (FormMaxValue) Property.GetCustomAttributes().FirstOrDefault(a => a.GetType() == typeof(FormMaxValue));
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
            innerGrid.Children.Add(entry, 1, 0);
            return innerGrid;
        }
    }
}
