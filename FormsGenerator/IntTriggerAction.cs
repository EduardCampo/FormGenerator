using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FormsGenerator
{
    public class IntTriggerAction : TriggerAction<Entry>
    {
        private string _prevValue = string.Empty;

        protected override void Invoke(Entry entry)
        {
            int n;
            var isNumeric = int.TryParse(entry.Text, out n);

            //entry.Text.Length > 4 ||  (to check length)
            if (!string.IsNullOrWhiteSpace(entry.Text) && !isNumeric)
            {
                entry.Text = _prevValue;
                return;
            }

            _prevValue = entry.Text;
        }
    }
}
