using System.Reflection;
using Xamarin.Forms;

namespace FormsGenerator.Strategy
{
    public class BoolSwitchStrategy : ViewStrategy
    {
        public BoolSwitchStrategy(PropertyInfo property) : base(property)
        {
        }
        public override View GetView()
        {
            return new Switch();
        }
    }
}
