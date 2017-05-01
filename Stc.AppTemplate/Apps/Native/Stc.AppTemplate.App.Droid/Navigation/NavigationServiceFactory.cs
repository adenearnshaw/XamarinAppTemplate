using Android.Content;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Stc.AppTemplate.App.Droid.Activities;
using Stc.AppTemplate.Core.UILogic.Navigation;

namespace Stc.AppTemplate.App.Droid.Navigation
{
    public class NavigationServiceFactory
    {
        public static INavigationService Get()
        {
            var service = new AppCompatNavigationService();

            service.Configure(ViewKeys.Main, typeof(MainActivity));

            return service;
        }

        public static object GetLastNavigationParameter(Intent intent)
        {
            var navSvc = ServiceLocator.Current.GetInstance<INavigationService>() as NavigationService;

            var param = navSvc?.GetAndRemoveParameter(intent);
            return param;
        }
    }
}