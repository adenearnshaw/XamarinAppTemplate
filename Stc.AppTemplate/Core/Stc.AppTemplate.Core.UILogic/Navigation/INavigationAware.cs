namespace Stc.AppTemplate.Core.UILogic.Navigation
{
    public interface INavigationAware
    {
        void OnNavigatedTo(object parameter);
        void OnNavigatedFrom();
    }
}