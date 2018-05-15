using System.Reflection;
using Xamarin.Forms;

namespace FormsGenerator.Strategy
{
    public class DatePickerStrategy : ViewStrategy
    {
        public DatePickerStrategy(PropertyInfo property) : base(property)
        {
        }
        public override View GetView()
        {
            return new DatePicker();
        }
    }
}
