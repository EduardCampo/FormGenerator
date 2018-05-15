using System.Reflection;
using FormsGenerator.Utilities;
using Xamarin.Forms;

namespace FormsGenerator.Strategy
{
    public abstract class ViewStrategy : IViewStrategy
    {
        private readonly int GridHeight;
        public PropertyInfo Property { get; }
        protected ViewStrategy(PropertyInfo property)
        {
            Property = property;
            if (Device.RuntimePlatform == Device.UWP)
            {
                GridHeight = 33;
            }
            else
            {
                GridHeight = 42;
            }

        }

        protected Label GetLabel(string text)
        {
            return new Label { Text = text, VerticalTextAlignment = TextAlignment.Center, FontSize = 16 };
        }

        public Grid GetGrid()
        {
            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(GridHeight, GridUnitType.Absolute) });
            grid.Children.Add(GetLabel(Property.Name.SplitCamelCase()), 0, 0);
            grid.Children.Add(GetView(), 1, 0);
            return grid;
        }
        public abstract View GetView();
    }
}
