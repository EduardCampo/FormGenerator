using FormsGenerator.Utilities;
using System;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace FormsGenerator
{

    public class FormPopupContentPage<T> : ContentPage
    {
        public T Model { get; set; }
        public string SubmitText { get; set; }

        public FormPopupContentPage(T model, string submitText)
        {
            Model = model;
            SubmitText = submitText;
        }

        public void SetContent(Grid grid)
        {
            var button = new Button
            {
                Text = SubmitText,
                
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
                var grid = (Grid)layoutscroll?.Children[0];
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

            var mainGrid = view as Layout<View>;
            var child = mainGrid.Children[1];
            if (child.GetType() == typeof(Grid))
            {
                var innerGrid = child as Layout<View>;
                child = innerGrid.Children[0];
            }
            viewTypeName = child.GetType().Name;

            switch (viewTypeName)
            {
                case ("Entry"):
                    var Entry = child as Entry;

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
                    var Switch = child as Switch;
                    return Switch.IsToggled;

                case ("Picker"):
                    var Picker = child as Picker;
                    return Picker.SelectedIndex;

                case ("DatePicker"):
                    var Date = child as DatePicker;
                    return Date.Date;

                case ("Slider"):
                    var Slider = child as Slider;
                    return (int)Slider.Value;

                default:
                    return null;
            }

            return null;
        }
    }
}
