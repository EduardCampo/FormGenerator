using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace FormsGenerator.Strategy
{
    public class IntSliderStrategy : ViewStrategy
    {
        public IntSliderStrategy(PropertyInfo property) : base(property)
        {
        }

        public override View GetView()
        {
            var slider = new Slider();
            var sliderOptions = (FormIntSlider)Property.GetCustomAttributes().FirstOrDefault(a => a.GetType() == typeof(FormIntSlider));
            var innerGrid = new Grid();
            innerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });
            innerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
            slider.Maximum = (double) sliderOptions.MaxValue;
            slider.Minimum = (double) sliderOptions.MinValue;
            slider.Value = (double) sliderOptions.DefaultValue;
            var label = new Label();
            label.SetBinding(Label.TextProperty, "Value", BindingMode.TwoWay, null, "{0:F0}");
            label.BindingContext = slider;
            label.HorizontalTextAlignment = TextAlignment.Center;
            label.VerticalTextAlignment = TextAlignment.Center;
            innerGrid.Children.Add(slider);
            innerGrid.Children.Add(label, 1, 0);
            return innerGrid;
        }
    }
}
