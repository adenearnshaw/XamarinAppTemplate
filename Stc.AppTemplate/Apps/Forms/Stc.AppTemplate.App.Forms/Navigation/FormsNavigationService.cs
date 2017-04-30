using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Views;
using Xamarin.Forms;

namespace Stc.AppTemplate.App.Forms.Navigation
{
    public class FormsNavigationService : INavigationService
    {
        private Dictionary<string, Type> pages { get; }
            = new Dictionary<string, Type>();

        public Page MainPage => Application.Current.MainPage;
        public string CurrentPageKey { get; private set; }

        public void Configure(string key, Type pageType) => pages[key] = pageType;

        public bool CanGoBack => MainPage.Navigation.NavigationStack.Count > 1;

        public void GoBack() => MainPage.Navigation.PopAsync();

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            Type pageType;
            if (pages.TryGetValue(pageKey, out pageType))
            {
                var displayPage = (Page)Activator.CreateInstance(pageType);
                displayPage.SetNavigationArgs(parameter);

                //if (historyBehavior == NavigationHistoryBehavior.ClearHistory)
                //{
                //    MainPage.Navigation.InsertPageBefore(displayPage, MainPage.Navigation.NavigationStack[0]);

                //    var existingPages = MainPage.Navigation.NavigationStack.ToList();
                //    for (int i = 1; i < existingPages.Count; i++)
                //    {
                //        MainPage.Navigation.RemovePage(existingPages[i]);
                //    }
                //}
                //else
                //{
                MainPage.Navigation.PushAsync(displayPage);
                CurrentPageKey = pageKey;
                //}
            }
            else
            {
                throw new ArgumentException($"No such page: {pageKey}.", nameof(pageKey));
            }
        }
    }
}