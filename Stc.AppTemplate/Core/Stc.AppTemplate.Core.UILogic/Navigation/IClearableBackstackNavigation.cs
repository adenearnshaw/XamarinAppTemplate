namespace Stc.AppTemplate.Core.UILogic.Navigation
{
    public interface IClearableBackstackNavigation
    {
        void NavigateTo(string pageKey, object parameter, bool clearTop);
    }
}