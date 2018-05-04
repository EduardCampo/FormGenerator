using System.Reflection;
using Xamarin.Forms;

namespace FormsGenerator.Strategy
{
    public interface IViewStrategy
    {
        View GetView();
        Label GetLabel(string text);
        Grid GetGrid();
    }
}
