using GalaSoft.MvvmLight.Views;
using Stc.AppTemplate.App.Forms.Views;
using Stc.AppTemplate.Core.UILogic.Navigation;

namespace Stc.AppTemplate.App.Forms.Navigation
{
    public static class NavigationServiceFactory
    {
        /// <summary>
        /// Builds the NavigationService and registers all pages with an appropriate key
        /// </summary>
        /// <returns></returns>
        public static INavigationService Get()
        {
            var navigationService = new FormsNavigationService();

            navigationService.Configure(ViewKeys.Main, typeof(MainPage));

            return navigationService;
        }
    }
}