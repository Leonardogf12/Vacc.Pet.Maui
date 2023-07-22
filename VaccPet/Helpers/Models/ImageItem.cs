using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccPet.MVVM.ViewModels;

namespace VaccPet.Helpers.Models
{   
    public class ImageItem : BaseViewModel
    {
        private string _imageUrl;
        public string ImageUrl
        {
            get => _imageUrl;
            set=>SetProperty(ref _imageUrl, value);
        }
    }

}
