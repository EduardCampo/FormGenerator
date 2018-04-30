using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FormsGenerator.Triggers
{
    public class StringTriggerAction : TriggerAction<Entry>
    {
        private string _prevValue = string.Empty;
        private readonly int _maxLength;
        public StringTriggerAction(int maxLength)
        {
            _maxLength = maxLength;
        }
        protected override void Invoke(Entry entry)
        {
            if (!string.IsNullOrWhiteSpace(entry.Text) && entry.Text.Length > _maxLength)
            {
                entry.Text = _prevValue;
                return;
            }

            _prevValue = entry.Text;
        }
    }
}
