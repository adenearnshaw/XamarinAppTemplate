using GalaSoft.MvvmLight;
using $safeprojectname$.Navigation;

namespace $safeprojectname$.ViewModels
{
    public abstract class BaseViewModel : ViewModelBase, INavigationAware
    {
        public virtual void OnNavigatedTo(object parameter)
        { }

        public virtual void OnNavigatedFrom()
        { }
    }
}