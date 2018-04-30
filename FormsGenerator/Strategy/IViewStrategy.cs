using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace FormsGenerator.Strategy
{
    public interface IViewStrategy
    {
        View GetView(PropertyInfo property = null);
    }
}
