using VaccPet.MVVM.ViewModels;

namespace VaccPet.Services.Navigation
{
    public interface INavigationService
    {
        Task NavigateToViewModelAsync<TViewModel>() where TViewModel : BaseViewModel;
        Task NavigateToViewModelAsync<TViewModel>(bool isAbsoluteRoute) where TViewModel : BaseViewModel;
        Task NavigateToViewModelAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;
        Task NavigateToPageAsync<T>(Dictionary<string, object> parameter) where T : IView;
        Task GoBackAsync(string quantityReturn);
                
    }
}
