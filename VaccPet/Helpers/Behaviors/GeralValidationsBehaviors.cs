using CommunityToolkit.Maui.Behaviors;

namespace VaccPet.Helpers.Behaviors
{
    public class GeralValidationsBehaviors<T> : Behavior<T> where T : BindableObject
    {
        public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid),
                                                                                          typeof(bool),
                                                                                          typeof(GeralValidationsBehaviors<T>),
                                                                                          true,
                                                                                          BindingMode.OneWayToSource);

        private bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value); }
        }

        protected override void OnAttachedTo(T bindable)
        {
            if (bindable is Picker picker)
            {
                picker.SelectedIndexChanged += OnPickerSelectedIndexChanged;
            }

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


        #region PICKER
        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            IsValid = ValidatePickerSelectedItem(picker.SelectedItem);
        }

        #endregion

        #region VALIDATORS - PICKER

        private bool ValidatePickerSelectedItem(object selectedItem)
        {
            if (selectedItem == null)
                return false;

            return true;
        }

        #endregion
    }
}
