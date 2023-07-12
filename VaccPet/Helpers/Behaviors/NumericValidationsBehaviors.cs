using CommunityToolkit.Maui.Behaviors;

namespace VaccPet.Helpers.Behaviors
{
    public class NumericValidationsBehaviors<T> : Behavior<T> where T : BindableObject
    {
        public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid),
                                                                                          typeof(bool),
                                                                                          typeof(NumericValidationsBehaviors<T>),
                                                                                          true,
                                                                                          BindingMode.OneWayToSource);

        private bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value); }
        }

        protected override void OnAttachedTo(T bindable)
        {
            if (bindable is Entry entry)
            {
                entry.TextChanged += OnEntryValueChanged;
            }

            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(T bindable)
        {
            if (bindable is Entry entry)
            {
                entry.TextChanged -= OnEntryValueChanged;
            }

            base.OnDetachingFrom(bindable);
        }


        #region TEXT_CHANGEDS - NUMERICS
        protected virtual void OnEntryValueChanged(object sender, TextChangedEventArgs args)
        {
            var entry = (Entry)sender;

            IsValid = ValidateDoubleValueText(entry.Text);

            entry.TextColor = IsValid ? Color.FromHex("#CED9FC") : Colors.IndianRed;
        }

        #endregion

        #region VALIDATORS - NUMERICS

        protected virtual bool ValidateDoubleValueText(string value)
        {
            if (value != "")
            {
                if (double.Parse(value) <= 0 || double.Parse(value) >= 100)
                    return false;
            }

            return true;
        }

        #endregion
    }
}
