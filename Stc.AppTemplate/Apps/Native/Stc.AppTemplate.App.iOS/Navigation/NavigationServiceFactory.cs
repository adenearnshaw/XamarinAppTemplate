using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Stc.AppTemplate.App.iOS.ViewControllers;
using Stc.AppTemplate.Core.UILogic.Navigation;
using UIKit;

namespace Stc.AppTemplate.App.iOS.Navigation
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