using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace FormsGenerator
{
    public class FormGenerator
    {
        public FormGenerator()
        {
        }
        /// <summary>
        /// Genereates a new form page based on the type of object provided.
        /// When clicking submit, all the info gets copied onto the instance of
        /// the calling party.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <returns></returns>
        public FormContentPage<T> GeneratePage<T>(T instance)
        {
            var formPage = new FormContentPage<T>(instance);

            var grid = new Grid { Margin = new Thickness(15, 5, 15, 5) };
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(4, GridUnitType.Star) });
            var currentRow = 0;

            foreach (var property in instance.GetType().GetProperties())
            {
                var strategy = new ViewStrategy(property);
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(40, GridUnitType.Absolute) });
                grid.Children.Add(GetLabel(property.Name.SplitCamelCase()), 0, currentRow);

                var type = property.PropertyType;
                if (type.BaseType == typeof(Enum)) type = type.BaseType;
                grid.Children.Add(strategy[type], 1, currentRow);

                currentRow++;
            }
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50, GridUnitType.Absolute) });
            
            formPage.SetContent(grid);
            return formPage;
        }

        private Label GetLabel(string text)
        {
            return new Label {Text = text, VerticalTextAlignment = TextAlignment.Center, FontSize = 16};
        }
    }
}