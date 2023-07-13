using CommunityToolkit.Maui.Behaviors;
using System.ComponentModel.DataAnnotations;
using VaccPet.MVVM.ViewModels;

namespace VaccPet.Helpers.Behaviors
{
    public class TextValidationsBehaviors<T> : Behavior<T> where T : BindableObject
    {
        bool validateFields = false;
        public bool ValidateFields
        {
            get { return validateFields; }
            set
            {
                this.validateFields = value;
                OnPropertyChanged();
            }
        }

        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value); }
        }


        public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid),
                                                                                          typeof(bool),
                                                                                          typeof(TextValidationsBehaviors<T>),
                                                                                          true,
                                                                                          BindingMode.OneWayToSource);
       
        private static void SetIsValid(BindableObject bindable, bool value)
        {
            bindable.SetValue(IsValidProperty, value);
        }
        protected override void OnAttachedTo(T bindable)
        {
            base.OnAttachedTo(bindable);

            if (bindable is Entry entry)
            {
                entry.TextChanged += OnEntryTextChanged;
            }
            else if (bindable is Editor editor)
            {
                editor.TextChanged += OnEditorTextChanged;
            }

            SetIsValid(bindable, false);
            base.OnAttachedTo(bindable);
        }
        protected override void OnDetachingFrom(T bindable)
        {
            if (bindable is Entry entry)
            {
                entry.TextChanged -= OnEntryTextChanged;
            }
            else if (bindable is Editor editor)
            {
                editor.TextChanged -= OnEditorTextChanged;
            }

            base.OnDetachingFrom(bindable);
        }


        #region CHANGES - TEXT
        protected virtual void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = (Entry)sender;

            bool isValid = ValidateEntryText(entry.Text);
            SetIsValid((BindableObject)sender, isValid);
            ValidateFields = isValid;
            entry.TextColor = isValid ? Color.FromHex("#CED9FC") : Colors.IndianRed;
        }

        private void OnEditorTextChanged(object sender, TextChangedEventArgs args)
        {
            var editor = (Editor)sender;

            bool isValid = ValidateEditorText(editor.Text);
            SetIsValid((BindableObject)sender, isValid);
            ValidateFields = isValid;
            editor.TextColor = isValid ? Color.FromHex("#CED9FC") : Colors.IndianRed;
        }
        #endregion

        #region VALIDATORS
        protected virtual bool ValidateEntryText(string text)
        {
            if (text.Length < 3 || text.Length >= 30)
                return false;

            return true;
        }

        protected virtual bool ValidateEditorText(string text)
        {
            if (text.Length < 5 || text.Length >= 100)
                return false;

            return true;
        }

        #endregion

    }
}
