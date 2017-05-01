using GalaSoft.MvvmLight.Views;
using Stc.AppTemplate.App.UWP.Views;
using Stc.AppTemplate.Core.UILogic.Navigation;

namespace Stc.AppTemplate.App.UWP.Navigation
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