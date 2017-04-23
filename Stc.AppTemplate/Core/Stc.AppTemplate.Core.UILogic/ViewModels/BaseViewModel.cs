using GalaSoft.MvvmLight;
using Stc.AppTemplate.Core.UILogic.Navigation;

namespace Stc.AppTemplate.Core.UILogic.ViewModels
{
    public abstract class BaseViewModel : ViewModelBase, INavigationAware
    {
        public virtual void OnNavigatedTo(object parameter)
        { }

        public virtual void OnNavigatedFrom()
        { }
    }
}