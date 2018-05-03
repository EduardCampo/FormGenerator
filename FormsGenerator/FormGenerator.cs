using System;
using System.Linq;
using System.Reflection;
using FormsGenerator.Strategy;
using FormsGenerator.Utilities;
using Xamarin.Forms;

namespace FormsGenerator
{
    public class FormGenerator
    {
        private readonly int GridHeight;
        public FormGenerator()
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                GridHeight =  33;
            }
            else
            {
                GridHeight = 42;
            }
            
        }

        /// <summary>
        /// Genereates a new form page based on the type of object provided. You must push the page using Navigation.
        /// When clicking submit, all the info gets copied onto the instance of the calling party.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <returns></returns>
        public FormContentPage<T> GeneratePage<T>(T instance)
        {
            var formPage = new FormContentPage<T>(instance);

            var grid = new Grid {Margin = new Thickness(15, 15, 15, 15)};
            grid.ColumnDefinitions.Add(new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)});
            grid.ColumnDefinitions.Add(new ColumnDefinition {Width = new GridLength(2, GridUnitType.Star)});
            var currentRow = 0;

            foreach (var property in instance.GetType().GetProperties())
            {
                var view = Strategy(property);
                if (!property.GetCustomAttributes().Contains(new FormIgnore()) && view != null)
                {
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(GridHeight, GridUnitType.Absolute) });
                    grid.Children.Add(GetLabel(property.Name.SplitCamelCase()), 0, currentRow);
                    grid.Children.Add(view, 1, currentRow);
                    currentRow++;
                }
            }

            grid.RowDefinitions.Add(new RowDefinition {Height = new GridLength(GridHeight, GridUnitType.Absolute)});

            formPage.SetContent(grid);
            return formPage;
        }

        private Label GetLabel(string text)
        {
            return new Label {Text = text, VerticalTextAlignment = TextAlignment.Center, FontSize = 16};
        }

        private View Strategy(PropertyInfo property)
        {
            IViewStrategy strat;
            if (property.PropertyType.BaseType == typeof(Enum))
            {
                strat = new EnumPickerStrategy();
            }
            else
            {
                switch (property.PropertyType.Name)
                {
                    case ("String"):
                        strat = new StringEntryStrategy(); break;
                    case ("Int32"):
                        var sliderOptions = (FormIntSlider)property.GetCustomAttributes().FirstOrDefault(a => a.GetType() == typeof(FormIntSlider));
                        if (sliderOptions != null)
                        {
                            strat = new IntSliderStrategy();
                        }
                        else
                        {
                            strat = new IntEntryStrategy();
                        }
                        break;
                    case ("Boolean"):
                        strat = new BoolSwitchStrategy();  break;
                    case ("DateTime"):
                        strat = new DatePickerStrategy();  break;
                    default:
                        return null;
                }

            }
            return strat.GetView(property);
        }
    }
}