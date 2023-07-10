using System.ComponentModel;
using System.Runtime.CompilerServices;
using VaccPet.Services.Navigation;

namespace VaccPet.MVVM.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region VARIABLES
        public INavigationService Navigation => DependencyService.Get<INavigationService>();

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region PROPS

        bool isBusy = false;
        public bool IsBusy
        {
            get { return this.isBusy; }
            set { SetProperty(ref this.isBusy, value); }
        }

        #endregion

        #region METHODS
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            var change = PropertyChanged;

            if (change == null)
                return;

            change.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
           [CallerMemberName] string name = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(name);
            return true;
        }
        #endregion
    }
}
