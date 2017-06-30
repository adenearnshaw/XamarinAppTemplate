namespace $safeprojectname$.Navigation
{
    public interface IClearableBackstackNavigation
    {
        void NavigateTo(string pageKey, object parameter, bool clearTop);
    }
}