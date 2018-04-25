using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace FormsGenerator
{
    public class FormContentPage<T> : ContentPage
    {
        public T Model { get; set; }

        public FormContentPage(T model)
        {
            Model = model;
        }

        public void SetContent(Grid grid)
        {
            var button = new Button
            {
                Text = "Submit",
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            button.Clicked += PopPage;
            var scroll = new ScrollView();
            var stack = new StackLayout();
            stack.Children.Add(grid);
            stack.Children.Add(button);
            scroll.Content = stack;
            Content = scroll;
        }

        async void PopPage(object sender, EventArgs e)
        {
            try
            {
                var scrollView = Content as ScrollView;
                var layoutscroll = scrollView?.Content as Layout<View>;
                var grid = (Grid) layoutscroll?.Children[0];
                var gridLayout = grid as Layout<View>;
                var views = gridLayout.Children;

                var properties = Model.GetType().GetProperties();
                var i = 0;
                foreach (var view in views)
                {
                    if (view.GetType() != typeof(Label))
                    {
                        properties[i].SetValue(Model, GetValue(properties[i], view));
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            await Navigation.PopAsync();
        }

        private Object GetValue(PropertyInfo prop, View view)
        {
            switch (view.GetType().Name)
            {
                case ("Entry"):
                    var Entry = view as Entry;
                    if (prop.PropertyType == typeof(int)) return Int32.Parse(Entry.Text); ;
                    return Entry.Text;
                case ("Switch"):
                    var Switch = view as Switch;
                    return Switch.IsToggled;
                case ("Picker"):
                    var Picker = view as Picker;
                    return Picker.SelectedIndex;
                case ("DatePicker"):
                    var Date = view as DatePicker;
                    return Date.Date;
                default:
                    return null;
            }
        }
    }
}