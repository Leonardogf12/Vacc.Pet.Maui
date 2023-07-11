using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccPet.Helpers
{
    public class TextValidatorBehaviors : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {            
            ((Entry)sender).TextColor = args.NewTextValue.Length < 4 ? Colors.IndianRed : Color.FromHex("#CED9FC");
        }
    }
}
