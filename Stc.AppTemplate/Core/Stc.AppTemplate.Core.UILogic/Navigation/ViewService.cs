using System;
using System.Diagnostics;
using GalaSoft.MvvmLight.Views;

namespace Stc.AppTemplate.Core.UILogic.Navigation
{
    public class ViewService : IViewService
    {
        private readonly INavigationService _navigationService;

        public ViewService(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void ReturnToMain()
        {
            ReturnTo(NavigationUrls.Main);
        }

        public void ShowMain()
        {
            Navigate(NavigationUrls.Main);
        }




        private void Navigate(string viewName, object parameter = null)
        {
            try
            {
                if (parameter == null)
                {
                    _navigationService.NavigateTo(viewName);
                }
                else
                {
                    _navigationService.NavigateTo(viewName, parameter);
                }
            }
            catch (Exception ex)
            {
                //Ignore
                Debug.WriteLine(ex.Message);
            }
        }

        private void ReturnTo(string viewName, object parameter = null)
        {
            try
            {
                var navSvc = _navigationService as IClearableBackstackNavigation;
                navSvc?.NavigateTo(viewName, parameter, true);
            }
            catch (Exception ex)
            {
                //Ignore
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
