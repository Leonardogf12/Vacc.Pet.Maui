using CommunityToolkit.Maui.Behaviors;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            SetIsValid(bindable, false);
            base.OnAttachedTo(bindable);
        }
        protected override void OnDetachingFrom(T bindable)
        {
            if (bindable is Picker picker)
            {
                picker.SelectedIndexChanged += OnPickerSelectedIndexChanged;
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
