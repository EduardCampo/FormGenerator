using System.Reflection;
using Xamarin.Forms;

namespace FormsGenerator.Strategy
{
    public interface IViewStrategy
    {
        View GetView(PropertyInfo property = null);
    }
}
