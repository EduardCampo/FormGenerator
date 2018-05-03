using System.Reflection;
using Xamarin.Forms;

namespace FormsGenerator.Strategy
{
    public class DatePickerStrategy : IViewStrategy
    {
        public View GetView(PropertyInfo property = null)
        {
            return new DatePicker();
        }
    }
}
