using System;
using System.Linq;
using System.Reflection;
using FormsGenerator.Strategy;
using Xamarin.Forms;

namespace FormsGenerator
{
    public class FormGenerator
    {
        /// <summary>
        /// Genereates a new form page based on the type of object provided. You must push the page using Navigation.
        /// When clicking submit, all the information collected gets copied onto the instance of the calling member.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="submitText"></param>
        /// <returns></returns>
        public FormContentPage<T> GeneratePage<T>(T instance, GridType gridType = GridType.Default, string submitText = "Submit")
        {
            var formPage = new FormContentPage<T>(instance, submitText);

            var mainGrid = new Grid {Margin = new Thickness(15, 15, 15, 15)};
            var currentRow = 0;

            foreach (var property in instance.GetType().GetProperties())
            {
                var view = Strategy(property, gridType);
                if (!property.GetCustomAttributes().Contains(new FormIgnore()) && view != null)
                {
                    mainGrid.Children.Add(view,0,currentRow);
                    currentRow++;
                }
            }
            formPage.SetContent(mainGrid);
            return formPage;
        }

        private View Strategy(PropertyInfo property, GridType gridType)
        {
            IViewStrategy strat;
            if (property.PropertyType.BaseType == typeof(Enum))
            {
                strat = new EnumPickerStrategy(property);
            }
            else
            {
                switch (property.PropertyType.Name)
                {
                    case ("String"):
                        strat = new StringEntryStrategy(property); break;
                    case ("Int32"):
                        var sliderOptions = (FormIntSlider)property.GetCustomAttributes().FirstOrDefault(a => a.GetType() == typeof(FormIntSlider));
                        if (sliderOptions != null)
                        {
                            strat = new IntSliderStrategy(property);
                        }
                        else
                        {
                            strat = new IntEntryStrategy(property);
                        }
                        break;
                    case ("Boolean"):
                        strat = new BoolSwitchStrategy(property);  break;
                    case ("DateTime"):
                        strat = new DatePickerStrategy(property);  break;
                    default:
                        return null;
                }
            }
            return strat.GetGrid(gridType);
        }
    }
}