using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace FormsGenerator.Strategy
{
    public class BoolSwitchStrategy : IViewStrategy
    {
        public View GetView(PropertyInfo property = null)
        {
            return new Switch();
        }
    }
}
