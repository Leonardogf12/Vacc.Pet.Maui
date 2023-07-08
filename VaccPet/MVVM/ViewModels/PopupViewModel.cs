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

        string imageName;
        public string ImageName
        {
            get => imageName;
            set => SetProperty(ref imageName, value);
        }

        string titleName;
        public string TitleName
        {
            get => titleName;
            set => SetProperty(ref titleName, value);
        }

        string content;
        public string Content
        {
            get => content;
            set => SetProperty(ref content, value);
        }

        string buttonAccept;
        public string ButtonAccept
        {
            get => buttonAccept;
            set => SetProperty(ref buttonAccept, value);
        }

        string buttonCancel;
        public string ButtonCancel
        {
            get => buttonCancel;
            set => SetProperty(ref buttonCancel, value);
        }

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
        object obj;
        public object Obj
        {
            get=> obj;
            set => SetProperty(ref obj, value);
        }


        #endregion

        public PopupViewModel()
        {                      
        }

        #region METHODS         
        public PopupViewModel SetParametersPopup(string firstButton, string secondButton, object Obj,
                                                 ICommand fisrtCommand = null, ICommand secondCommand = null)
        {
            PopupViewModel model = new PopupViewModel()
            {
               Obj = Obj,
               FirstButton = firstButton,
               SecondButton = secondButton,
               FirstCommand = fisrtCommand,
               SecondCommand = secondCommand
            };

            return model;
        }
      
        #endregion

    }
}
