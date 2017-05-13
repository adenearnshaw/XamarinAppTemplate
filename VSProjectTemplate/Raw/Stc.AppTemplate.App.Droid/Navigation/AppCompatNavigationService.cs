using System;
using System.Collections.Generic;
using Android.Content;
using GalaSoft.MvvmLight.Views;
using $safeprojectname$.Activities;
using $safeprojectname$.Core.UILogic.Navigation;

namespace $safeprojectname$.Navigation
{
    public class AppCompatNavigationService : INavigationService, IClearableBackstackNavigation
    {
        private readonly Dictionary<string, Type> _pagesByKey = new Dictionary<string, Type>();
        private readonly Dictionary<string, object> _parametersByKey = new Dictionary<string, object>();

        private const string RootPageKey = "-- ROOT --";
        private const string ParameterKeyName = "ParameterKey";

        public string CurrentPageKey => BaseActivity.CurrentActivity.ActivityKey ?? RootPageKey;

        public void GoBack()
        {
            BaseActivity.GoBack();
        }

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null, false);
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            NavigateTo(pageKey, parameter, false);
        }

        public void NavigateTo(string pageKey, object parameter, bool clearTop)
        {
            BaseActivity.CurrentActivity.RunOnUiThread(() =>
            {
                if (BaseActivity.CurrentActivity == null)
                    throw new InvalidOperationException("No CurrentActivity found");

                lock (_pagesByKey)
                {
                    if (!_pagesByKey.ContainsKey(pageKey))
                    {
#if DEBUG
                        throw new ArgumentException(
                            $"No such page: {pageKey}. Did you forget to call NavigationService.Configure?",
                            nameof(pageKey));
#else
                        return;
#endif
                    }

                    var intent = new Intent(BaseActivity.CurrentActivity, _pagesByKey[pageKey]);

                    if (clearTop)
                    {
                        intent.AddFlags(ActivityFlags.ClearTop);
                    }

                    if (parameter != null)
                    {
                        lock (_parametersByKey)
                        {
                            var guid = Guid.NewGuid().ToString();
                            _parametersByKey.Add(guid, parameter);
                            intent.PutExtra(ParameterKeyName, guid);
                        }
                    }

                    BaseActivity.CurrentActivity.StartActivity(intent);
                    BaseActivity.NextPageKey = pageKey;
                }
            });
        }

        public void Configure(string key, Type activityType)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(key))
                    _pagesByKey[key] = activityType;
                else
                    _pagesByKey.Add(key, activityType);
            }
        }

        public object GetAndRemoveParameter(Intent intent)
        {
            if (intent == null)
                throw new ArgumentNullException(nameof(intent), "This method must be called with a valid Activity intent");

            var stringExtra = intent.GetStringExtra(ParameterKeyName);
            if (string.IsNullOrEmpty(stringExtra))
                return null;

            lock (_parametersByKey)
                return _parametersByKey.ContainsKey(stringExtra) ? _parametersByKey[stringExtra] : null;
        }

        public T GetAndRemoveParameter<T>(Intent intent)
        {
            return (T)GetAndRemoveParameter(intent);
        }
    }
}