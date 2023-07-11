using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VaccPet.MVVM.Models;
using VaccPet.Services;

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
        public PopupViewModel SetParametersPopup(string firstButton = "", string secondButton = "", string tertiaryButton = "", object obj = null,
                                                 ICommand fisrtCommand = null, ICommand secondCommand = null,
                                                 ICommand tertiaryCommand = null)
        {
            return new PopupViewModel()
            {
                FirstButton = firstButton,
                SecondButton = secondButton,
                TertiaryButton = tertiaryButton,
                Obj = obj,
                FirstCommand = fisrtCommand,
                SecondCommand = secondCommand,
                TertiaryCommand = tertiaryCommand
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
