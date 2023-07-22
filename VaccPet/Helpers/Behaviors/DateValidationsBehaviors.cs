namespace VaccPet.Helpers.Behaviors
{
    public class DateValidationsBehaviors<T> : Behavior<T> where T : BindableObject
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
                                                                                          typeof(DateValidationsBehaviors<T>),
                                                                                          true,
                                                                                          BindingMode.OneWayToSource);
      
        protected override void OnAttachedTo(T bindable)
        {
            if (bindable is DatePicker datePicker)
            {
                datePicker.DateSelected += OnDateSelectedChanged;
            }

            base.OnAttachedTo(bindable);
        }
        protected override void OnDetachingFrom(T bindable)
        {
            if (bindable is DatePicker datePicker)
            {
                datePicker.DateSelected -= OnDateSelectedChanged;
            }

            base.OnDetachingFrom(bindable);
        }


        #region CHANGES - DATE

        private void OnDateSelectedChanged(object sender, DateChangedEventArgs e)
        {
            var date = (DatePicker)sender;
            bool isValid = ValidateDateSelected(date.Date);
            ValidateFields = isValid;

            date.TextColor = isValid ? Color.FromHex("#181C2C") : Colors.IndianRed;
        }

        #endregion

        #region VALIDATORS

        private bool ValidateDateSelected(DateTime dateSelected)
        {
            if (dateSelected >= DateTime.Now)
                return false;

            return true;
        }

        #endregion
    }
}
