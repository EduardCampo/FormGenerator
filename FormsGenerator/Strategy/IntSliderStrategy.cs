using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace FormsGenerator.Strategy
{
    public class IntSliderStrategy : IViewStrategy
    {
        public View GetView(PropertyInfo property = null)
        {
            var slider = new Slider();

            var sliderOptions = (FormIntSlider)property.GetCustomAttributes().FirstOrDefault(a => a.GetType() == typeof(FormIntSlider));
            if (sliderOptions != null)
            {
                var grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
                slider.Maximum = (double) sliderOptions.MaxValue;
                slider.Minimum = (double) sliderOptions.MinValue;
                slider.Value = (double) sliderOptions.DefaultValue;
                var label = new Label();
                label.SetBinding(Label.TextProperty, "Value", BindingMode.TwoWay, null, "{0:F0}");
                label.BindingContext = slider;
                label.HorizontalTextAlignment = TextAlignment.Center;
                label.VerticalTextAlignment = TextAlignment.Center;
                grid.Children.Add(slider);
                grid.Children.Add(label, 1, 0);
                return grid;

            }
            return slider;
        }
    }
}
