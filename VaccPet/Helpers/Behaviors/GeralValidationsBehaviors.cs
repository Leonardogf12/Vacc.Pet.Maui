using DevExpress.Maui.Editors;

namespace VaccPet.Helpers.Behaviors
{
    public class GeralValidationsBehaviors<T> : Behavior<T> where T : BindableObject
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
                                                                                          typeof(GeralValidationsBehaviors<T>),
                                                                                          true,
                                                                                          BindingMode.OneWayToSource);

        private static void SetIsValid(BindableObject bindable, bool value)
        {
            bindable.SetValue(IsValidProperty, value);
        }
        protected override void OnAttachedTo(T bindable)
        {
            if (bindable is Picker picker)
            {
                picker.SelectedIndexChanged += OnPickerSelectedIndexChanged;
            }

            if (bindable is ComboBoxEdit comboBox)
            {
                comboBox.SelectionChanged += OnComboBoxEditSelectedIndexChanged;
            }

            SetIsValid(bindable, false);
            base.OnAttachedTo(bindable);
        }
        protected override void OnDetachingFrom(T bindable)
        {
            if (bindable is Picker picker)
            {
                picker.SelectedIndexChanged -= OnPickerSelectedIndexChanged;
            }

            if (bindable is ComboBoxEdit comboBox)
            {
                comboBox.SelectionChanged -= OnComboBoxEditSelectedIndexChanged;
            }

            base.OnDetachingFrom(bindable);
        }


        #region CHANGES - PICKER
        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            bool isValid = ValidatePickerSelectedItem(picker.SelectedItem);
            SetIsValid((BindableObject)sender, isValid);
            ValidateFields = isValid;

            picker.TitleColor = isValid ? Color.FromHex("#181C2C") : Colors.IndianRed;
        }

        private void OnComboBoxEditSelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBoxEdit)sender;
            bool isValid = ValidatePickerSelectedItem(comboBox.SelectedItem);
            SetIsValid((BindableObject)sender, isValid);
            ValidateFields = isValid;

            comboBox.BorderColor = isValid ? Color.FromHex("#181C2C") : Colors.IndianRed;
        }
        

        #endregion

        #region VALIDATORS

        private bool ValidatePickerSelectedItem(object selectedItem)
        {
            if (selectedItem == null)
                return false;

            return true;
        }

        #endregion
    }
}
