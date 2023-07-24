using System.Windows.Input;

namespace VaccPet.MVVM.ViewModels
{
    public class PopupViewModel : BaseViewModel
    {

        #region PROPS

        string firstButton;
        public string FirstButton
        {
            get => firstButton;
            set => SetProperty(ref firstButton, value);
        }


        string secondButton;
        public string SecondButton
        {
            get => secondButton;
            set => SetProperty(ref secondButton, value);
        }


        string tertiaryButton;
        public string TertiaryButton
        {
            get => tertiaryButton;
            set => SetProperty(ref tertiaryButton, value);
        }

        string quartenaryButton;
        public string QuartenaryButton
        {
            get => quartenaryButton;
            set => SetProperty(ref quartenaryButton, value);
        }


        ICommand firstCommand;
        public ICommand FirstCommand
        {
            get => firstCommand;
            set => SetProperty(ref firstCommand, value);
        }


        ICommand secondCommand;
        public ICommand SecondCommand
        {
            get => secondCommand;
            set => SetProperty(ref secondCommand, value);
        }


        ICommand tertiaryCommand;
        public ICommand TertiaryCommand
        {
            get => tertiaryCommand;
            set => SetProperty(ref tertiaryCommand, value);
        }

        ICommand quartenaryCommand;
        public ICommand QuartenaryCommand
        {
            get => quartenaryCommand;
            set => SetProperty(ref quartenaryCommand, value);
        }


        object obj;
        public object Obj
        {
            get => obj;
            set => SetProperty(ref obj, value);
        }


        string message;
        public string Message
        {
            get=> message;
            set=> SetProperty(ref message, value);
        }

       
        #endregion

        public PopupViewModel()
        {
        }

        #region METHODS         
        public PopupViewModel SetParametersPopup(string firstButton = "", string secondButton = "",
                                                 string tertiaryButton = "", string quartenaryButton = "", object obj = null,
                                                 ICommand fisrtCommand = null, ICommand secondCommand = null,
                                                 ICommand tertiaryCommand = null, ICommand quartenatyCommand = null)
        {
            return new PopupViewModel()
            {
                FirstButton = firstButton,
                SecondButton = secondButton,
                TertiaryButton = tertiaryButton,
                QuartenaryButton = quartenaryButton,
                Obj = obj,
                FirstCommand = fisrtCommand,
                SecondCommand = secondCommand,
                TertiaryCommand = tertiaryCommand,
                QuartenaryCommand = quartenatyCommand
            };
        }

        public PopupViewModel SetParametersPopup(string message = "")
        {
            return new PopupViewModel()
            {
               Message = message
            };
        }

        
        #endregion

    }
}
