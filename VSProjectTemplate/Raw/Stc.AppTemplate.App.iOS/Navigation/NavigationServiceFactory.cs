using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using $safeprojectname$.ViewControllers;
using $safeprojectname$.Core.UILogic.Navigation;
using UIKit;

namespace $safeprojectname$.Navigation
{
    public static class NavigationServiceFactory
    {
        public static INavigationService Get()
        {
            var service = new NavigationService();

            service.Configure(ViewKeys.Main, typeof(MainViewController));

            return service;
        }

        public static object GetLastNavigationParameter(this UIViewController controller)
        {
            var navSvc = ServiceLocator.Current.GetInstance<INavigationService>() as NavigationService;

            var param = navSvc?.GetAndRemoveParameter(controller);
            return param;
        }
    }
}