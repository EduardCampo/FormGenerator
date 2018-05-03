using System;
using System.Linq;
using System.Reflection;
using FormsGenerator.Utilities;
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
                    if (properties[i].GetCustomAttributes().Contains(new FormIgnore()))
                    {
                        i++;
                    }
                    if (view.GetType() != typeof(Label))
                    {
                        var value = GetValue(properties[i], view);
                        if (value == null) return;
                        properties[i].SetValue(Model, value);
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
            var viewTypeName = view.GetType().Name;
            if (viewTypeName == "Grid")
            {
                var gridLayout = view as Layout<View>;
                view = gridLayout.Children[0];
                viewTypeName = view.GetType().Name;
            }

            switch (viewTypeName)
            {
                case ("Entry"):
                    var Entry = view as Entry;

                    if (!string.IsNullOrWhiteSpace(Entry.Text) ||
                        prop.GetCustomAttributes().Contains(new FormOptional()))
                    {
                        if (prop.PropertyType == typeof(int)) return Int32.Parse(Entry.Text);
                        return Entry.Text + "";
                    }

                    var name = prop.Name.SplitCamelCase();
                    DisplayAlert(name + " missing", "Please fill the " + name + " field", "OK");
                    break;

                case ("Switch"):
                    var Switch = view as Switch;
                    return Switch.IsToggled;

                case ("Picker"):
                    var Picker = view as Picker;
                    return Picker.SelectedIndex;

                case ("DatePicker"):
                    var Date = view as DatePicker;
                    return Date.Date;

                case ("Slider"):
                    var Slider = view as Slider;
                    return (int) Slider.Value;

                default:
                    return null;
            }

            return null;
        }
    }
}