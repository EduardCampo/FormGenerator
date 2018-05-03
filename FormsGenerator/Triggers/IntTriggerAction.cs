using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FormsGenerator.Triggers
{
    public class IntTriggerAction : TriggerAction<Entry>
    {
        private string _prevValue = string.Empty;
        private readonly int _maxValue;

        public IntTriggerAction(int maxValue = int.MaxValue)
        {
            _maxValue = maxValue;
        }
        protected override void Invoke(Entry entry)
        {
            var isNumeric = int.TryParse(entry.Text, out int n);

            if (!string.IsNullOrWhiteSpace(entry.Text) && !isNumeric)
            {
                entry.Text = _prevValue;
                return;
            }
            if (n > _maxValue)
            {
                entry.Text = _maxValue.ToString();
                return;
            }

            _prevValue = entry.Text;
        }
    }
}
