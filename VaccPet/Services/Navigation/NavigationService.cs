using VaccPet.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace VaccPet.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        #region VIEWMODEL
        public async Task NavigateToViewModelAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            await InternalNavigateToViewModelAsync(typeof(TViewModel), null, false);
        }
        public async Task NavigateToViewModelAsync<TViewModel>(bool isAbsoluteRoute) where TViewModel : BaseViewModel
        {
            await InternalNavigateToViewModelAsync(typeof(TViewModel), null, isAbsoluteRoute);
        }
        public async Task NavigateToViewModelAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            await InternalNavigateToViewModelAsync(typeof(TViewModel), parameter, false);
        }
        async Task InternalNavigateToViewModelAsync(Type viewModelType, object parameter, bool isAbsoluteRoute = false)
        {
            var viewName = viewModelType.FullName.Replace("ViewModels", "Views").Replace("ViewModel", "Page");
            string absolutePrefix = isAbsoluteRoute ? "///" : String.Empty;
            if (parameter != null)
            {
                await Shell.Current.GoToAsync(
                    $"{absolutePrefix}{viewName}?id={HttpUtility.UrlEncode(parameter.ToString())}");
            }
            else
            {
                await Shell.Current.GoToAsync($"{absolutePrefix}{viewName}");
            }
        }
        #endregion
        
        #region VIEW
        public async Task NavigateToPageAsync<T>(Dictionary<string, object> parameter) where T : IView
        {
            await InternalNavigateToPageAsync(typeof(T), parameter);
        }
        async Task InternalNavigateToPageAsync(Type viewType, Dictionary<string, object> parameter)
        {
            if (parameter != null)
                await Shell.Current.GoToAsync($"{viewType.Name}", parameter);
            else
                await Shell.Current.GoToAsync($"{viewType.Name}");
        }
        #endregion

        public async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
