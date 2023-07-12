using CommunityToolkit.Maui.Behaviors;
using static System.Net.Mime.MediaTypeNames;

namespace VaccPet.Helpers.Behaviors
{
    public class DateValidationsBehaviors<T> : Behavior<T> where T : BindableObject
    {
        public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid),
                                                                                          typeof(bool),
                                                                                          typeof(DateValidationsBehaviors<T>),
                                                                                          true,
                                                                                          BindingMode.OneWayToSource);

        private bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value); }
        }

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


        #region DATE_CHANGEDS - DATE

        private void OnDateSelectedChanged(object sender, DateChangedEventArgs e)
        {
            var date = (DatePicker)sender;

            IsValid = ValidateDateSelected(date.Date);

            date.TextColor = IsValid ? Color.FromHex("#CED9FC") : Colors.IndianRed;
        }


        #endregion

        #region VALIDATORS - DATE

        private bool ValidateDateSelected(DateTime dateSelected)
        {
            if (dateSelected >= DateTime.Now)
                return false;

            return true;
        }

        #endregion
    }
}
