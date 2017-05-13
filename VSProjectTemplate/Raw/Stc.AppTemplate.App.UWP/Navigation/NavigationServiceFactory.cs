using GalaSoft.MvvmLight.Views;
using $safeprojectname$.Views;
using $safeprojectname$.Core.UILogic.Navigation;

namespace $safeprojectname$.Navigation
{
    public static class NavigationServiceFactory
    {
        public static INavigationService Get()
        {
            var navSvc = new NavigationService();

            navSvc.Configure(ViewKeys.Main, typeof(MainPage));

            return navSvc;
        }
    }
}