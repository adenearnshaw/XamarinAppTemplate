using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using $safeprojectname$.Core.UILogic.Navigation;

namespace $safeprojectname$.Views
{
    public class BasePage : Page
    {
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            (DataContext as INavigationAware)?.OnNavigatedTo(e.Parameter);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            (DataContext as INavigationAware)?.OnNavigatedFrom();
        }
    }
}