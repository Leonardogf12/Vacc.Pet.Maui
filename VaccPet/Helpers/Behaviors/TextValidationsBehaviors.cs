using CommunityToolkit.Maui.Behaviors;
using System.ComponentModel.DataAnnotations;
using VaccPet.MVVM.ViewModels;

namespace VaccPet.Helpers.Behaviors
{
    public class TextValidationsBehaviors<T> : Behavior<T> where T : BindableObject
    {
        bool validateB;
        public bool ValidateB
        {
            get { return validateB; }
            set
            {
                this.validateB = value;
                OnPropertyChanged();
            }
        }


        public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid),
                                                                                          typeof(bool),
                                                                                          typeof(TextValidationsBehaviors<T>),
                                                                                          true,
                                                                                          BindingMode.OneWayToSource);

        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value); }
        }


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
            //base.OnAttachedTo(bindable);
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



        #region TEXT_CHANGEDS - TEXT
        protected virtual void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = (Entry)sender;

            bool isValid = ValidateEntryText(entry.Text);
            SetIsValid((BindableObject)sender, isValid);
            ValidateB = isValid;
            entry.TextColor = isValid ? Color.FromHex("#CED9FC") : Colors.IndianRed;
        }

        private void OnEditorTextChanged(object sender, TextChangedEventArgs args)
        {
            var editor = (Editor)sender;

            IsValid = ValidateEditorText(editor.Text);

            editor.TextColor = IsValid ? Color.FromHex("#CED9FC") : Colors.IndianRed;
        }
        #endregion

        #region VALIDATORS - TEXT
        protected virtual bool ValidateEntryText(string text)
        {
            if (text.Length < 3 || text.Length >= 15)
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
