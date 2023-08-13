using System.ComponentModel;
using System.Web;
using VaccPet.Helpers.Buttons;
using VaccPet.MVVM.ViewModels;

namespace VaccPet.Services.Navigation
{
    public class NavigationService : INavigationService
    {

        public ImageButtonAnimationHelper _imageButtonAnimationHelper;

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
        public async Task NavigateToPageAsync<T>(Dictionary<string, object> parameter, View component = null) where T : IView
        {
            await InternalNavigateToPageAsync(typeof(T), parameter, component);
        }

        async Task InternalNavigateToPageAsync(Type viewType, Dictionary<string, object> parameter, View component = null)
        {
            _imageButtonAnimationHelper = new ImageButtonAnimationHelper();

            if (component != null)
                await _imageButtonAnimationHelper.AnimateScaleViewElement(component);

            if (parameter != null)
                await Shell.Current.GoToAsync($"{viewType.Name}", parameter);
            else
                await Shell.Current.GoToAsync($"{viewType.Name}");
        }

        public async Task GoBackAsync(string quantityReturn, View component = null)
        {
            _imageButtonAnimationHelper = new ImageButtonAnimationHelper();

            if (component != null)
                await _imageButtonAnimationHelper.AnimateScaleViewElement(component);

            //*Caso queira voltar 2 views, passe o parametro assim ->  "..\\.."            
            await Shell.Current.GoToAsync(quantityReturn);
        }
        #endregion
    }
}
