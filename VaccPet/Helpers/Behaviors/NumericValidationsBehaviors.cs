using CommunityToolkit.Maui.Behaviors;

namespace VaccPet.Helpers.Behaviors
{
    public class NumericValidationsBehaviors<T> : Behavior<T> where T : BindableObject
    {
        bool validateFields;
        public bool ValidateFields
        {
            get { return validateFields; }
            set
            {
                this.validateFields = value;
                OnPropertyChanged();
            }
        }

        private bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value); }
        }


        public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid),
                                                                                          typeof(bool),
                                                                                          typeof(NumericValidationsBehaviors<T>),
                                                                                          true,
                                                                                          BindingMode.OneWayToSource);
        
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

        #region CHANGES - NUMERICS
        protected virtual void OnEntryValueChanged(object sender, TextChangedEventArgs args)
        {
            var entry = (Entry)sender;

            bool isValid = ValidateDoubleValueText(entry.Text);
            ValidateFields = isValid;

            entry.TextColor = isValid ? Color.FromHex("#CED9FC") : Colors.IndianRed;
        }

        #endregion

        #region VALIDATORS

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
