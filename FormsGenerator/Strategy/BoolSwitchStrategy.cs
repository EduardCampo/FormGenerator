using System.Reflection;
using Xamarin.Forms;

namespace FormsGenerator.Strategy
{
    public class BoolSwitchStrategy : IViewStrategy
    {
        public View GetView(PropertyInfo property = null)
        {
            return new Switch();
        }
    }
}
